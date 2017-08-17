﻿using System;
using System.Collections.Generic;
using System.Linq;
using LiveCharts.Defaults;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;
using QOBDCommon.Entities;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using QOBDViewModels.Interfaces;
using QOBDCommon.Enum;
using QOBDCommon.Classes;
using System.Configuration;
using QOBDModels.Models;
using QOBDModels.Classes;
using QOBDViewModels.Abstracts;
using QOBDModels.Command;
using System.Windows.Media;
using QOBDModels.Enums;

namespace QOBDViewModels.ViewModel
{
    public class StatisticViewModel : Classes.ViewModel
    {
        private SeriesCollection _purchaseAndSalePriceseriesCollection;
        private SeriesCollection _payReceivedSeries;
        private ChartValues<DateTimePoint> _chartValueList;
        private List<StatisticModel> _statisticList;
        private List<ToDo> _toDoList;
        private string _newTask;
        private string _taskFileName;
        private string _taskFileFullName;

        //----------------------------[ Models ]------------------

        private ItemModel _firstBestSeller;
        private ItemModel _secondBestSeller;
        private ItemModel _ThirdBestSeller;
        private ItemModel _fourthBestSeller;
        private SeriesCollection _creditSeries;
        private IMainWindowViewModel _main;
        private Func<object, object> _page;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<ToDo> DeleteToDoTaskCommand { get; set; }


        public StatisticViewModel(IMainWindowViewModel mainWindowViewModel)
        {
            _main = mainWindowViewModel;
        }

        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
            PropertyChanged += onNewTaskChange_SaveToToDoList;
        }

        private void instances()
        {
            _toDoList = new List<ToDo>();
            _firstBestSeller = (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            _secondBestSeller = (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            _ThirdBestSeller = (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            _fourthBestSeller = (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            _taskFileName = "tasks.xml";
            _taskFileFullName = Utility.getOrCreateDirectory(ConfigurationManager.AppSettings["local_doc_task_folder"], _taskFileName);
            _purchaseAndSalePriceseriesCollection = new SeriesCollection();
            _payReceivedSeries = new SeriesCollection();
            _creditSeries = new SeriesCollection();
        }

        private void instancesCommand()
        {
            DeleteToDoTaskCommand = _main.CommandCreator.createSingleInputCommand<ToDo>(deleteTask, canDeleteTask);
        }

        //----------------------------[ Properties ]------------------

        public BusinessLogic Bl
        {
            get { return _main.Startup.Bl; }
        }

        public List<StatisticModel> StatisticDataList
        {
            get { return _statisticList; }
            set
            {
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                        _statisticList = value;
                    else
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _statisticList = value;
                        });
                    onPropertyChange("StatisticDataList");
                }
            }
        }

        public ItemModel FirstBestItemModelSeller
        {
            get { return _firstBestSeller; }
            set
            {
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                        _firstBestSeller = value;
                    else
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _firstBestSeller = value;
                        });
                    onPropertyChange("FirstBestItemModelSeller");
                }
            }
        }

        public ItemModel SecondBestItemModelSeller
        {
            get { return _secondBestSeller; }
            set
            {
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                        _secondBestSeller = value;
                    else
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _secondBestSeller = value;
                        });
                    onPropertyChange("SecondBestItemModelSeller");
                }
            }
        }

        public ItemModel ThirdBestItemModelSeller
        {
            get { return _ThirdBestSeller; }
            set
            {
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                        _ThirdBestSeller = value;
                    else
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _ThirdBestSeller = value;
                        });
                    onPropertyChange("ThirdBestItemModelSeller");
                }
            }
        }

        public ItemModel FourthBestItemModelSeller
        {
            get { return _fourthBestSeller; }
            set
            {
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                        _fourthBestSeller = value;
                    else
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _fourthBestSeller = value;
                        });
                    onPropertyChange("FourthBestItemModelSeller");
                }
            }
        }

        public List<ToDo> ToDoList
        {
            get { return _toDoList; }
            set
            {
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                        _toDoList = value;
                    else
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _toDoList = value;
                        });
                    onPropertyChange("ToDoList");
                }
            }
        }

        public string TxtNewTask
        {
            get { return _newTask; }
            set { _newTask = value; onPropertyChange("TxtNewTask"); }
        }

        public SeriesCollection PurchaseAndIncomeSeriesCollection
        {
            get { return _purchaseAndSalePriceseriesCollection; }
            set
            {
                if (Application.Current != null)
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _purchaseAndSalePriceseriesCollection = value; onPropertyChange("PurchaseAndIncomeSeriesCollection");
                    });
            }
        }

        public SeriesCollection PayReceivedSeriesCollection
        {
            get { return _payReceivedSeries; }
            set
            {
                if (Application.Current != null)
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        setProperty(ref _payReceivedSeries, value, "PayReceivedSeriesCollection");
                    });
            }
        }

        public SeriesCollection CreditSeriesCollection
        {
            get { return _creditSeries; }
            set
            {
                if (Application.Current != null)
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        setProperty(ref _creditSeries, value, "CreditSeriesCollection");
                    });
            }
        }

        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public string[] PurchaseAndIncomeLabels { get; set; }
        public string[] PayReceivedAndBillLabels { get; set; }

        private string readTxtNewTask()
        {
            return _newTask;
        }

        private void setTxtNewTask(string task)
        {
            _newTask = task;
        }
        //----------------------------[ Actions ]------------------
        
        public override async void load()
        {
            StatisticDataList = (await Bl.BlStatisitc.searchStatisticAsync(new Statistic { Option = 1 }, ESearchOption.AND)).Select(x => new StatisticModel { Statistic = x }).ToList();
            ToDoList = getToDoTasks();
            loadUIData();
        }

        private void loadUIData()
        {
            loadDataGauge();
            loadPurchaseAndIncomeChart();
        }

        private void salesChart()
        {
            var payReceivedChartValue = new ChartValues<decimal>();
            var invoiceAmountChartValue = new ChartValues<decimal>();

            payReceivedChartValue.AddRange(StatisticDataList.OrderBy(x => x.Statistic.ID).Select(x => x.Statistic.Total).ToList());

            CreditSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Pay received",
                    Values = payReceivedChartValue
                }
            };

            PayReceivedAndBillLabels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }; ;// StatisticDataList.OrderBy(x => x.Statistic.ID).Select(x => x.Statistic.InvoiceDate.ToString("MMM")).ToArray();

        }

        private void loadPurchaseAndIncomeChart()
        {
            var purchaseChartValue = new ChartValues<decimal>();
            var IncomeChartValue = new ChartValues<decimal>();
            var BillAmountChartValue = new ChartValues<decimal>();

            purchaseChartValue.AddRange(StatisticDataList.OrderBy(x => x.Statistic.ID).Select(x => x.Statistic.Price_purchase_total).ToList());
            IncomeChartValue.AddRange(StatisticDataList.OrderBy(x => x.Statistic.ID).Select(x => x.Statistic.Income).ToList());
            BillAmountChartValue.AddRange(StatisticDataList.OrderBy(x => x.Statistic.ID).Select(x => x.Statistic.Total_tax_included).ToList());

            PurchaseAndIncomeSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sale",
                    Values = BillAmountChartValue
                },
                new LineSeries
                {
                    Title = "Purchase",
                    Values = purchaseChartValue
                },
                new LineSeries
                {
                    Title = "Income",
                    Values = IncomeChartValue
                }
            };

            PurchaseAndIncomeLabels = StatisticDataList.OrderBy(x => x.Statistic.ID).Select(x => x.Statistic.Bill_datetime.ToString("MMMM")).ToArray();
            //Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
        }

        private void loadDataGauge()
        {
            getBestSellers();
        }

        public async void getBestSellers()
        {
            // getting four best sellers
            var itemBestSsellerList = await Bl.BlItem.searchItemAsync(new Item { Option = (int)EStatisticOption.GET10BESTSELLERS }, ESearchOption.AND);
            FirstBestItemModelSeller = itemBestSsellerList.OrderByDescending(x => x.Number_of_sale).Select(x => new ItemModel { Item = x }).FirstOrDefault() ?? (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            SecondBestItemModelSeller = itemBestSsellerList.OrderByDescending(x => x.Number_of_sale).Where(x => x.Number_of_sale < FirstBestItemModelSeller.Item.Number_of_sale).Select(x => new ItemModel { Item = x }).FirstOrDefault() ?? (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            ThirdBestItemModelSeller = itemBestSsellerList.OrderByDescending(x => x.Number_of_sale).Where(x => x.Number_of_sale < SecondBestItemModelSeller.Item.Number_of_sale).Select(x => new ItemModel { Item = x }).FirstOrDefault() ?? (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);
            FourthBestItemModelSeller = itemBestSsellerList.OrderByDescending(x => x.Number_of_sale).Where(x => x.Number_of_sale < ThirdBestItemModelSeller.Item.Number_of_sale).Select(x => new ItemModel { Item = x }).FirstOrDefault() ?? (ItemModel)_main.ModelCreator.createModel(QOBDModels.Enums.EModel.ITEM);

        }

        private void loadChartPayreceivedData()
        {
            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };

            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            PayReceivedSeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Values = GetDataPayreceived(),
                        Fill = gradientBrush,
                        StrokeThickness = 1,
                        PointGeometrySize = 0
                    }
                };


            XFormatter = val => new DateTime((long)val).ToString("dd MMM");
            YFormatter = val => val.ToString("C");
        }


        private ChartValues<DateTimePoint> GetDataPayreceived()
        {
            loadStatisticPayReceived();
            return _chartValueList;
        }

        private void loadStatisticPayReceived()
        {
            _chartValueList = new ChartValues<DateTimePoint>();
            var statistics = StatisticDataList.OrderBy(x => x.Statistic.Date_limit).ToList();
            foreach (var statisticModel in statistics)
            {
                _chartValueList.Add(new DateTimePoint(statisticModel.Statistic.Pay_date, (double)statisticModel.Statistic.Pay_received));
            }
        }

        private void setNewTask()
        {
            var toDo = new ToDo();
            toDo.PropertyChanged += onToDoListIsDoneChange;
            toDo.TxtTask = TxtNewTask;
            ToDoList.Add(toDo);
            ToDoList = new List<ToDo>(ToDoList);
        }

        private void saveToDoTasks(List<ToDo> taskList)
        {
            using (StreamWriter sw = new StreamWriter(_taskFileFullName))
            {
                XmlSerializer xs = new XmlSerializer(taskList.GetType());
                xs.Serialize(sw, taskList);
            }
        }

        private List<ToDo> getToDoTasks()
        {
            List<ToDo> results = new List<ToDo>();
            FileInfo fileInfo = new FileInfo(_taskFileFullName);
            if (File.Exists(_taskFileFullName) && fileInfo.Length > 0)
            {
                using (StreamReader sr = new StreamReader(_taskFileFullName))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<ToDo>));
                    results = (List<ToDo>)xs.Deserialize(sr);
                }
                foreach (var todo in results)
                    todo.PropertyChanged += onToDoListIsDoneChange;
            }
            return results;
        }

        public override void Dispose()
        {
            PropertyChanged -= onNewTaskChange_SaveToToDoList;
        }

        //----------------------------[ Event Handler ]------------------

        private void onNewTaskChange_SaveToToDoList(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("TxtNewTask"))
            {
                setNewTask();
                saveToDoTasks(ToDoList);
            }
        }

        private void onToDoListIsDoneChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsDone"))
            {
                saveToDoTasks(ToDoList);
            }
        }

        //----------------------------[ Action Commands ]------------------


        private void deleteTask(ToDo obj)
        {
            ToDoList.Remove(obj);
            ToDoList = new List<ToDo>(ToDoList);
            saveToDoTasks(ToDoList);
        }

        private bool canDeleteTask(ToDo arg)
        {
            return true;
        }

        public void executeNavig(string obj)
        {
            switch (obj)
            {
                case "home":
                    _page(this);
                    break;
                default:
                    goto case "home";
            }
        }

        private bool canExecuteNavig(string arg)
        {
            return true;
        }

    }
}
