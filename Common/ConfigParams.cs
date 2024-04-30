using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Common;
namespace AharHighLevel.Common
{
    public static class ConfigParams
    {
        public static List<NetVariable> AllParams { get; set; }
        public static List<AlarmEventVariable> AllAlarmEvents { get; set; }
        public static List<NetVariable> TrendParams { get; set; }
        static ConfigParams()
        {
            AllParams = new List<NetVariable>();

            #region ' Form Parameters '

            #region ' 11 '
            // SetrNet102
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 999,
                Resolution = .1m,
                Unit = "MVA",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Power",
                PacketNumber = 1,
                NetValue = 400,
                FormId = 111,
                PacketIndex = 4 * 0,
                MainIndex = 10102,
            });
            // SetrNet103
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 99,
                Resolution = .01m,
                Unit = "KV",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Voltage",
                PacketNumber = 2,
                NetValue = 20,
                FormId = 111,
                PacketIndex = 4 * 1,
                MainIndex = 10103,
            });
            // SetrNet104
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 99,
                Resolution = .01m,
                Unit = "KA",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Current",
                PacketNumber = 3,
                NetValue = 12,
                FormId = 111,
                PacketIndex = 4 * 2,
                MainIndex = 10104,
            });
            // SetrNet105
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 1,
                Resolution = .05m,
                Unit = "",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Power Factor",
                PacketNumber = 4,
                NetValue = 0.8m,
                FormId = 111,
                PacketIndex = 4 * 3,
                MainIndex = 10105,
            });
            // SetrNet106
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 60,
                Resolution = 1,
                Unit = "Hz",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Frequency",
                PacketNumber = 5,
                NetValue = 50,
                FormId = 111,
                PacketIndex = 4 * 4,
                MainIndex = 10106,
            });
            // SetrNet107
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 3270,
                Resolution = .1m,
                Unit = "A",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Current",
                PacketNumber = 6,
                NetValue = 3240,
                FormId = 112,
                PacketIndex = 4 * 5,
                MainIndex = 10107,
            });
            // SetrNet108
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "V",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rated Voltage",
                PacketNumber = 7,
                NetValue = 421,
                FormId = 112,
                PacketIndex = 4 * 6,
                MainIndex = 10108,
            });
            // SetrNet109
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 327,
                Resolution = .01m,
                Unit = '\u03A9'.ToString(),
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Resistance",
                PacketNumber = 8,
                NetValue = 0.13m,
                FormId = 112,
                PacketIndex = 4 * 7,
                MainIndex = 10109,
            });
            // SetrNet110
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 99,
                Resolution = .01m,
                Unit = "H",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Inductance",
                PacketNumber = 9,
                NetValue = 0.75m,
                FormId = 112,
                PacketIndex = 4 * 8,
                MainIndex = 10110,
            });
            // SetbNet5
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Excitation Type",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 113,
                PacketIndex = 4 * 11,
                MainIndex = 20005,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Static" ,
        "Dynamic" ,
    },
            });
            // SetbNet6
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Self-Excitation",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 113,
                PacketIndex = 4 * 11,
                MainIndex = 20006,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetbNet7
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Power Supply Redundancy",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 113,
                PacketIndex = 4 * 11,
                MainIndex = 20007,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetrNet23
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 500,
                Resolution = 1m,
                Unit = "Hz",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Power Supply Rated Frequency",
                PacketNumber = 10,
                NetValue = 50,
                FormId = 113,
                PacketIndex = 4 * 9,
                MainIndex = 10023,
            });
            // SetrNet24
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "V",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Power Supply Rated Voltage",
                PacketNumber = 11,
                NetValue = 700,
                FormId = 113,
                PacketIndex = 4 * 10,
                MainIndex = 10024,
            });
            #endregion
            #region ' 12 '
            // SetrNet37
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 30,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Reactive Droop Compensation",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 121,
                PacketIndex = 4 * 0,
                MainIndex = 10037,
            });
            // SetrNet38
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 30,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Line Droop Compensation",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 121,
                PacketIndex = 4 * 1,
                MainIndex = 10038,
            });
            // Sete2Net12
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Droop Type",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 121,
                PacketIndex = 4 * 2,
                MainIndex = 30012,
                PacketSubIndex = 3,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Reactive" ,
        "Line" ,
    },
            });
            // SetbNet8
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Power Bridge Topology",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 122,
                PacketIndex = 4 * 2,
                MainIndex = 20008,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "3Phase" ,
        "1Phase" ,
    },
            });
            // SetbNet9
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "System Redundancy",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 122,
                PacketIndex = 4 * 2,
                MainIndex = 20009,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Single" ,
        "Redundant" ,
    },
            });
            // SetbNet10
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Pre Control",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 122,
                PacketIndex = 4 * 2,
                MainIndex = 20010,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Deactive" ,
        "Active" ,
    },
            });
            #endregion
            #region ' 13 '
            // SetrNet18
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 99,
                Resolution = .01m,
                Unit = "KV",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Primary Voltage",
                PacketNumber = 1,
                NetValue = 20,
                FormId = 131,
                PacketIndex = 4 * 0,
                MainIndex = 10018,
            });
            // SetrNet19
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 999,
                Resolution = .5m,
                Unit = "V",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Secondary Voltage",
                PacketNumber = 2,
                NetValue = 110,
                FormId = 131,
                PacketIndex = 4 * 1,
                MainIndex = 10019,
            });
            // SetrNet20
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 99,
                Resolution = .01m,
                Unit = "KA",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Primary Current",
                PacketNumber = 3,
                NetValue = 12,
                FormId = 132,
                PacketIndex = 4 * 2,
                MainIndex = 10020,
            });
            // SetrNet21
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9,
                Resolution = .1m,
                Unit = "A",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Secondary Current",
                PacketNumber = 4,
                NetValue = 5,
                FormId = 132,
                PacketIndex = 4 * 3,
                MainIndex = 10021,
            });
            // SetrNet22
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Network Type",
                PacketNumber = 5,
                NetValue = 1,
                FormId = 133,
                PacketIndex = 4 * 4,
                MainIndex = 10022,
            });
            // SetrNet39
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -2,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Active Power Gain",
                PacketNumber = 6,
                NetValue = 1,
                FormId = 134,
                PacketIndex = 4 * 5,
                MainIndex = 10039,
            });
            // SetrNet40
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -2,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Reactive Power Gain",
                PacketNumber = 7,
                NetValue = 1,
                FormId = 134,
                PacketIndex = 4 * 6,
                MainIndex = 10040,
            });
            // SetrNet41
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -2,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Voltage Gain",
                PacketNumber = 8,
                NetValue = 1,
                FormId = 134,
                PacketIndex = 4 * 7,
                MainIndex = 10041,
            });
            // SetrNet42
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -2,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Current Gain",
                PacketNumber = 9,
                NetValue = 1,
                FormId = 134,
                PacketIndex = 4 * 8,
                MainIndex = 10042,
            });
            // SetrNet43
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -2,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Power Factor Gain",
                PacketNumber = 10,
                NetValue = 1,
                FormId = 134,
                PacketIndex = 4 * 9,
                MainIndex = 10043,
            });
            // SetrNet44
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -2,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Frequency Gain",
                PacketNumber = 11,
                NetValue = 1,
                FormId = 134,
                PacketIndex = 4 * 10,
                MainIndex = 10044,
            });
            // SetrNet25
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Power Meter Error Time Delay",
                PacketNumber = 12,
                NetValue = 0.1m,
                FormId = 135,
                PacketIndex = 4 * 11,
                MainIndex = 10025,
            });
            // SetrNet26
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Voltage Redundancy Fault Time Delay",
                PacketNumber = 13,
                NetValue = 1,
                FormId = 135,
                PacketIndex = 4 * 12,
                MainIndex = 10026,
            });
            // SetrNet45
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Voltage Redundancy Fault Interval limit",
                PacketNumber = 14,
                NetValue = 30,
                FormId = 135,
                PacketIndex = 4 * 13,
                MainIndex = 10045,
            });
            // SetrNet46
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Voltage Redundancy Fault Hysteresis",
                PacketNumber = 15,
                NetValue = 2,
                FormId = 135,
                PacketIndex = 4 * 14,
                MainIndex = 10046,
            });
            //        // MntrNet0
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "KV",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet0",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 15,
            //            MainIndex = 10000,
            //        });
            //        // MntrNet1
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "KA",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet1",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 16,
            //            MainIndex = 10001,
            //        });
            //        // MntrNet2
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "MW",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet2",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 17,
            //            MainIndex = 10002,
            //        });
            //        // MntrNet3
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "MVAr",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet3",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 18,
            //            MainIndex = 10003,
            //        });
            //        // MntrNet4
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet4",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 19,
            //            MainIndex = 10004,
            //        });
            //        // MntrNet5
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "Hz",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet5",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 20,
            //            MainIndex = 10005,
            //        });
            //        // MntbNet0
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet0",
            //            PacketNumber = 17,
            //            NetValue = 0,
            //            FormId = 136,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 30000,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            //        // MntbNet1
            //        AllParams.Add(new BoolVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "Logic",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet1",
            //            PacketNumber = 11,
            //            NetValue = false,
            //            FormId = 136,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 20001,
            //            PacketSubIndex = 1,
            //        });
            //        // MntbNet2
            //        AllParams.Add(new BoolVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "Logic",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet2",
            //            PacketNumber = 11,
            //            NetValue = false,
            //            FormId = 136,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 20002,
            //            PacketSubIndex = 2,
            //        });
            //        // MntbNet3
            //        AllParams.Add(new BoolVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "Logic",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet3",
            //            PacketNumber = 11,
            //            NetValue = false,
            //            FormId = 136,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 20003,
            //            PacketSubIndex = 3,
            //        });
            #endregion
            #region ' 14 '
            // SetrNet35
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "External Transformer Ratio",
                PacketNumber = 2,
                NetValue = 1,
                FormId = 141,
                PacketIndex = 4 * 1,
                MainIndex = 10035,
            });
            // SetrNet36
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = .1m,
                Unit = "V",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Cable Connection",
                PacketNumber = 1,
                NetValue = 1000,
                FormId = 141,
                PacketIndex = 4 * 0,
                MainIndex = 10036,
            });
            // SetrNet101
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 1000,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Excitation Voltage Lag Time",
                PacketNumber = 3,
                NetValue = 10,
                FormId = 141,
                PacketIndex = 4 * 2,
                MainIndex = 10101,
            });
            // SetbNet0
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Feedback Type",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 142,
                PacketIndex = 4 * 10,
                MainIndex = 20000,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "CT" ,
        "Shunt" ,
    },
            });
            // SetrNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 2,
                Resolution = .01m,
                Unit = "V",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "CT load Voltage",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 142,
                PacketIndex = 4 * 3,
                MainIndex = 10000,
            });
            // SetrNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10000,
                Resolution = 1,
                Unit = "u" + '\u03A9', //(char)234,
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Shunt Ratio",
                PacketNumber = 5,
                NetValue = 1,
                FormId = 142,
                PacketIndex = 4 * 4,
                MainIndex = 10001,
            });
            // SetrNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Excitation Current Lag Time",
                PacketNumber = 6,
                NetValue = 4,
                FormId = 142,
                PacketIndex = 4 * 5,
                MainIndex = 10002,
            });
            // SetrNet14
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Kp-Proportional Gain",
                PacketNumber = 7,
                NetValue = 1,
                FormId = 143,
                PacketIndex = 4 * 6,
                MainIndex = 10014,
            });
            // SetrNet15
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ti- Integral Time",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 143,
                PacketIndex = 4 * 7,
                MainIndex = 10015,
            });
            // SetrNet16
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Td- Derivative Time",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 143,
                PacketIndex = 4 * 8,
                MainIndex = 10016,
            });
            // SetrNet17
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10000,
                Resolution = 1,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "N- Derivative Filter",
                PacketNumber = 10,
                NetValue = 1,
                FormId = 143,
                PacketIndex = 4 * 9,
                MainIndex = 10017,
            });
            //        // MntrNet6
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "Deg",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet6",
            //            PacketNumber = 12,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 11,
            //            MainIndex = 10006,
            //        });
            //        // MntrNet7
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "KV",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet7",
            //            PacketNumber = 13,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 12,
            //            MainIndex = 10007,
            //        });
            //        // MntrNet8
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "KA",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet8",
            //            PacketNumber = 14,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 13,
            //            MainIndex = 10008,
            //        });
            //        // MntrNet9
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "MW",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet9",
            //            PacketNumber = 15,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 14,
            //            MainIndex = 10009,
            //        });
            //        // MntrNet10
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "MVAr",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet10",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 15,
            //            MainIndex = 10010,
            //        });
            //        // MntrNet11
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet11",
            //            PacketNumber = 17,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 16,
            //            MainIndex = 10011,
            //        });
            //        // MntrNet11
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "Hz",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet11",
            //            PacketNumber = 18,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 17,
            //            MainIndex = 10011,
            //        });
            //        // MntbNet4
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet4",
            //            PacketNumber = 19,
            //            NetValue = 0,
            //            FormId = 144,
            //            PacketIndex = 4 * 18,
            //            MainIndex = 30004,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            #endregion
            #region ' 21 '
            // SetrNet111
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 1,
                NetValue = 110,
                FormId = 211,
                PacketIndex = 4 * 0,
                MainIndex = 10111,
            });
            // SetrNet112
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 211,
                PacketIndex = 4 * 1,
                MainIndex = 10112,
            });
            // SetrNet159
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "%/s",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Synchronic  Rate",
                PacketNumber = 3,
                NetValue = 1,
                FormId = 211,
                PacketIndex = 4 * 2,
                MainIndex = 10159,
            });
            // SetrNet113
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 4,
                NetValue = 107,
                FormId = 212,
                PacketIndex = 4 * 3,
                MainIndex = 10113,
            });
            // SetrNet114
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 5,
                NetValue = 93,
                FormId = 212,
                PacketIndex = 4 * 4,
                MainIndex = 10114,
            });
            // SetrNet160
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 5,
                Resolution = .01m,
                Unit = "%/s",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "AVR Loading Rate",
                PacketNumber = 6,
                NetValue = .2m,
                FormId = 212,
                PacketIndex = 4 * 5,
                MainIndex = 10160,
            });
            // SetrNet161
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 5,
                Resolution = .01m,
                Unit = "%/s",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Reactive Loading Rate",
                PacketNumber = 7,
                NetValue = .05m,
                FormId = 212,
                PacketIndex = 4 * 6,
                MainIndex = 10161,
            });
            // SetrNet115
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Set Point Initial Value",
                PacketNumber = 8,
                NetValue = 10,
                FormId = 213,
                PacketIndex = 4 * 7,
                MainIndex = 10115,
            });
            // SetbNet12
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Force Enable",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 214,
                PacketIndex = 4 * 9,
                MainIndex = 20012,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetrNet162
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Force Value",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 214,
                PacketIndex = 4 * 8,
                MainIndex = 10162,
            });
            // MntrNet13
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 10,
                MainIndex = 10013,
            });
            // MntrNet14
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vc",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 11,
                MainIndex = 10014,
            });
            // MntrNet15
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 12,
                MainIndex = 10015,
            });
            // MntrNet16
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 13,
                MainIndex = 10016,
            });
            // MntrNet17
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 14,
                MainIndex = 10017,
            });
            // MntrNet18
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Frequency",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 15,
                MainIndex = 10018,
            });
            // MntrNet19
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Setpoint",
                PacketNumber = 17,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 16,
                MainIndex = 10019,
            });
            //// MntrNet20
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "KV",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet20",
            //    PacketNumber = 18,
            //    NetValue = 0,
            //    FormId = 215,
            //    PacketIndex = 4 * 17,
            //    MainIndex = 10020,
            //});
            // MntrNet21
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "FCR Setpoint",
                PacketNumber = 18,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 17,
                MainIndex = 10021,
            });
            // MntrNet22
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "If",
                PacketNumber = 19,
                NetValue = 0,
                FormId = 215,
                PacketIndex = 4 * 18,
                MainIndex = 10022,
            });
            //        // MntbNet5
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet5",
            //            PacketNumber = 21,
            //            NetValue = 0,
            //            FormId = 215,
            //            PacketIndex = 4 * 20,
            //            MainIndex = 30005,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            #endregion
            #region ' 22 '
            // SetrNet116
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 1,
                NetValue = 110,
                FormId = 221,
                PacketIndex = 4 * 0,
                MainIndex = 10116,
            });
            // SetrNet117
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 221,
                PacketIndex = 4 * 1,
                MainIndex = 10117,
            });
            // SetrNet163
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 5,
                Resolution = .01m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Loading Rate",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 221,
                PacketIndex = 4 * 2,
                MainIndex = 10163,
            });
            // SetrNet164
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "No Load Current",
                PacketNumber = 4,
                NetValue = 30,
                FormId = 222,
                PacketIndex = 4 * 3,
                MainIndex = 10164,
            });
            // SetbNet13
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Force Enable",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 223,
                PacketIndex = 4 * 5,
                MainIndex = 20013,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetrNet165
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Force Value",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 223,
                PacketIndex = 4 * 4,
                MainIndex = 10165,
            });
            // MntrNet23
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 6,
                MainIndex = 10023,
            });
            //// MntrNet24
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "KA",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet24",
            //    PacketNumber = 8,
            //    NetValue = 0,
            //    FormId = 224,
            //    PacketIndex = 4 * 7,
            //    MainIndex = 10024,
            //});
            // MntrNet25
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 7,
                MainIndex = 10025,
            });
            // MntrNet26
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 8,
                MainIndex = 10026,
            });
            // MntrNet27
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 9,
                MainIndex = 10027,
            });
            // MntrNet28
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Frequency",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 10,
                MainIndex = 10028,
            });
            // MntrNet29
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Setpoint",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 11,
                MainIndex = 10029,
            });
            // MntrNet30
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "FCR Setpoint",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 12,
                MainIndex = 10030,
            });
            // MntrNet31
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IF",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 13,
                MainIndex = 10031,
            });
            // MntrNet32
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IF_Ref",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 224,
                PacketIndex = 4 * 14,
                MainIndex = 10032,
            });
            //        // MntbNet6
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet6",
            //            PacketNumber = 17,
            //            NetValue = 0,
            //            FormId = 224,
            //            PacketIndex = 4 * 16,
            //            MainIndex = 30006,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            #endregion
            #region ' 23 '
            // SetrNet166
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Soft Start Time",
                PacketNumber = 1,
                NetValue = 25,
                FormId = 231,
                PacketIndex = 4 * 0,
                MainIndex = 10166,
            });
            // SetrNet118
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Power Ready Fault Time Delay",
                PacketNumber = 2,
                NetValue = 30,
                FormId = 231,
                PacketIndex = 4 * 1,
                MainIndex = 10118,
            });
            // SetrNet119
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Raise Pulse Timer",
                PacketNumber = 3,
                NetValue = 1,
                FormId = 231,
                PacketIndex = 4 * 2,
                MainIndex = 10119,
            });
            // SetrNet120
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Lower Pulse Timer",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 231,
                PacketIndex = 4 * 3,
                MainIndex = 10120,
            });
            // SetrNet121
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 60,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Maximum Field Flash Time",
                PacketNumber = 5,
                NetValue = 15,
                FormId = 232,
                PacketIndex = 4 * 4,
                MainIndex = 10121,
            });
            // SetrNet122
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Field Flash Start Time Delay",
                PacketNumber = 6,
                NetValue = 1,
                FormId = 232,
                PacketIndex = 4 * 5,
                MainIndex = 10122,
            });
            // SetrNet123
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Field Flash Overlap  Time",
                PacketNumber = 7,
                NetValue = 2,
                FormId = 232,
                PacketIndex = 4 * 6,
                MainIndex = 10123,
            });
            // Vt
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Unit = "%",
                IsReadOnly = true,
                Label = "Vt",
                PacketNumber = 8,
                FormId = 233,
                PacketIndex = 4 * 7,
            });
            // Vf
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Unit = "%",
                IsReadOnly = true,
                Label = "Vf",
                PacketNumber = 9,
                FormId = 233,
                PacketIndex = 4 * 8,
            });
            // VL
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Unit = "%",
                IsReadOnly = true,
                Label = "VL",
                PacketNumber = 10,
                FormId = 233,
                PacketIndex = 4 * 9,
            });
            // IF
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Unit = "%",
                IsReadOnly = true,
                Label = "IF",
                PacketNumber = 11,
                FormId = 233,
                PacketIndex = 4 * 10,
            });
            // 41F
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "41F",
                PacketNumber = 12,
                NetValue = false,
                FormId = 233,
                PacketIndex = 4 * 11,
                PacketSubIndex = 0,
            });
            // 41FY
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "41FY",
                PacketNumber = 12,
                NetValue = false,
                FormId = 233,
                PacketIndex = 4 * 11,
                PacketSubIndex = 1,
            });
            // 72FF
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "72FF",
                PacketNumber = 12,
                NetValue = false,
                FormId = 233,
                PacketIndex = 4 * 11,
                PacketSubIndex = 2,
            });
            #endregion
            #region ' 31 '
            // SetrNet47
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Kp-Proportional Gain",
                PacketNumber = 1,
                NetValue = 1,
                FormId = 311,
                PacketIndex = 4 * 0,
                MainIndex = 10047,
            });
            // SetrNet48
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ti- Integral Time",
                PacketNumber = 2,
                NetValue = 1,
                FormId = 311,
                PacketIndex = 4 * 1,
                MainIndex = 10048,
            });
            // SetrNet49
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Td- Derivative Time",
                PacketNumber = 3,
                NetValue = 1,
                FormId = 311,
                PacketIndex = 4 * 2,
                MainIndex = 10049,
            });
            // SetrNet50
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10000,
                Resolution = 1,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "N- Derivative Filter",
                PacketNumber = 4,
                NetValue = 1000,
                FormId = 311,
                PacketIndex = 4 * 3,
                MainIndex = 10050,
            });
            // SetrNet51
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "SetrNet51",
                PacketNumber = 5,
                NetValue = 161,
                FormId = 312,
                PacketIndex = 4 * 4,
                MainIndex = 10051,
            });
            // SetrNet52
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 6,
                NetValue = .1m,
                FormId = 312,
                PacketIndex = 4 * 5,
                MainIndex = 10052,
            });
            // MntrNet33
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 6,
                MainIndex = 10033,
            });
            // MntrNet34
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Current",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 7,
                MainIndex = 10034,
            });
            // MntrNet35
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 8,
                MainIndex = 10035,
            });
            // MntrNet36
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 9,
                MainIndex = 10036,
            });
            // MntrNet37
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 10,
                MainIndex = 10037,
            });
            // MntrNet38
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "Hz",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Frequency",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 11,
                MainIndex = 10038,
            });
            // MntrNet39
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Out",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 12,
                MainIndex = 10039,
            });
            // MntrNet40
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Out 2nd Sanyar",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 13,
                MainIndex = 10040,
            });
            // MntrNet41
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IF_Ref",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 14,
                MainIndex = 10041,
            });
            // MntrNet42
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vc",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 15,
                MainIndex = 10042,
            });
            // AvSet
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Setpoint",
                PacketNumber = 17,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 16,
                MainIndex = 10042,
            });
            // PSO
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "PSS out",
                PacketNumber = 18,
                NetValue = 0,
                FormId = 313,
                PacketIndex = 4 * 17,
                MainIndex = 10042,
            });
            //        // MntbNet7
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet7",
            //            PacketNumber = 17,
            //            NetValue = 0,
            //            FormId = 313,
            //            PacketIndex = 4 * 16,
            //            MainIndex = 30007,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            #endregion
            #region ' 32 '
            // SetrNet53
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 1,
                NetValue = 200,
                FormId = 321,
                PacketIndex = 4 * 0,
                MainIndex = 10053,
            });
            // SetrNet54
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 321,
                PacketIndex = 4 * 1,
                MainIndex = 10054,
            });
            // SetrNet55
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "SetrNet55",
                PacketNumber = 3,
                NetValue = 1,
                FormId = 322,
                PacketIndex = 4 * 2,
                MainIndex = 10055,
            });
            // SetrNet56
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ti- Integral Time",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 322,
                PacketIndex = 4 * 3,
                MainIndex = 10056,
            });
            // SetrNet57
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Td- Derivative Time",
                PacketNumber = 5,
                NetValue = 1,
                FormId = 322,
                PacketIndex = 4 * 4,
                MainIndex = 10057,
            });
            // SetrNet58
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10000,
                Resolution = 1,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "N- Derivative Filter",
                PacketNumber = 6,
                NetValue = 1000,
                FormId = 322,
                PacketIndex = 4 * 5,
                MainIndex = 10058,
            });
            // SetrNet59
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 7,
                NetValue = 100,
                FormId = 323,
                PacketIndex = 4 * 6,
                MainIndex = 10059,
            });
            // SetrNet60
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 323,
                PacketIndex = 4 * 7,
                MainIndex = 10060,
            });
            // SetrNet61
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "deg",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 9,
                NetValue = 150,
                FormId = 324,
                PacketIndex = 4 * 8,
                MainIndex = 10061,
            });
            // SetrNet62
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "deg",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 10,
                NetValue = 30,
                FormId = 324,
                PacketIndex = 4 * 9,
                MainIndex = 10062,
            });
            //// MntrNet43
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "KV",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet43",
            //    PacketNumber = 11,
            //    NetValue = 0,
            //    FormId = 325,
            //    PacketIndex = 4 * 10,
            //    MainIndex = 10043,
            //});
            //// MntrNet44
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "KA",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet44",
            //    PacketNumber = 12,
            //    NetValue = 0,
            //    FormId = 325,
            //    PacketIndex = 4 * 11,
            //    MainIndex = 10044,
            //});
            //// MntrNet45
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "MW",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet45",
            //    PacketNumber = 13,
            //    NetValue = 0,
            //    FormId = 325,
            //    PacketIndex = 4 * 12,
            //    MainIndex = 10045,
            //});
            //// MntrNet46
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "MVAr",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet46",
            //    PacketNumber = 14,
            //    NetValue = 0,
            //    FormId = 325,
            //    PacketIndex = 4 * 13,
            //    MainIndex = 10046,
            //});
            // MntrNet47
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IF",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 325,
                PacketIndex = 4 * 10,
                MainIndex = 10047,
            });
            // MntrNet48
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IF_Ref",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 325,
                PacketIndex = 4 * 11,
                MainIndex = 10048,
            });
            //// MntrNet49
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet49",
            //    PacketNumber = 17,
            //    NetValue = 0,
            //    FormId = 325,
            //    PacketIndex = 4 * 16,
            //    MainIndex = 10049,
            //});
            // MntrNet50
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "FCR Out",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 325,
                PacketIndex = 4 * 12,
                MainIndex = 10050,
            });
            // MntrNet51
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "FCR Out 2nd Sanyar",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 325,
                PacketIndex = 4 * 13,
                MainIndex = 10051,
            });
            // MntrNet52
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Pre_Out",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 325,
                PacketIndex = 4 * 14,
                MainIndex = 10052,
            });
            // MntrNet53
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution =0,
                Unit = "deg",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Alpha",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 325,
                PacketIndex = 4 * 15,
                MainIndex = 10053,
            });
            //        // MntbNet8
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet8",
            //            PacketNumber = 22,
            //            NetValue = 0,
            //            FormId = 325,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 30008,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            #endregion
            #region ' 33 '
            // SetrNet124
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 500,
                Resolution = 1,
                Unit = "MVAr",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 1,
                NetValue = 300,
                FormId = 331,
                PacketIndex = 4 * 0,
                MainIndex = 10124,
            });
            // SetrNet125
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -500,
                Max = 0,
                Resolution = 1,
                Unit = "MVAr",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 2,
                NetValue = -200,
                FormId = 331,
                PacketIndex = 4 * 1,
                MainIndex = 10125,
            });
            // SetrNet167
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "MVAr/s",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Loading Rate",
                PacketNumber = 3,
                NetValue = 1,
                FormId = 332,
                PacketIndex = 4 * 2,
                MainIndex = 10167,
            });
            // SetrNet126
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Reactive Feedback Filter Time",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 332,
                PacketIndex = 4 * 3,
                MainIndex = 10126,
            });

            // SetrNet168
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Interval Limit (L)",
                PacketNumber = 5,
                NetValue = 1,
                FormId = 332,
                PacketIndex = 4 * 4,
                MainIndex = 10168,
            });
            // SetrNet169
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Hysteresis (HY)",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 332,
                PacketIndex = 4 * 5,
                MainIndex = 10169,
            });
            // SetrNet127
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Average Interval Value (M)",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 332,
                PacketIndex = 4 * 6,
                MainIndex = 10127,
            });
            // MntrNet54
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 7,
                MainIndex = 10054,
            });
            // MntrNet55
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Current",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 8,
                MainIndex = 10055,
            });
            // MntrNet56
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 9,
                MainIndex = 10056,
            });
            // MntrNet57
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 10,
                MainIndex = 10057,
            });
            // MntrNet58
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 11,
                MainIndex = 10058,
            });
            //// MntrNet59
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "Hz",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet59",
            //    PacketNumber = 13,
            //    NetValue = 0,
            //    FormId = 333,
            //    PacketIndex = 4 * 12,
            //    MainIndex = 10059,
            //});
            // MntrNet60
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Q Setpoint",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 12,
                MainIndex = 10060,
            });
            // MntrNet61
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "PF Setpoint",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 333,
                PacketIndex = 4 * 13,
                MainIndex = 10061,
            });
            //// MntrNet62
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet62",
            //    PacketNumber = 16,
            //    NetValue = 0,
            //    FormId = 333,
            //    PacketIndex = 4 * 15,
            //    MainIndex = 10062,
            //});
            //// MntrNet63
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet63",
            //    PacketNumber = 17,
            //    NetValue = 0,
            //    FormId = 333,
            //    PacketIndex = 4 * 16,
            //    MainIndex = 10063,
            //});
            // MntbNet10
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "Q Raise",
                PacketNumber = 15,
                NetValue = false,
                FormId = 333,
                PacketIndex = 4 * 14,
                MainIndex = 20010,
                PacketSubIndex = 0,
            });
            // MntbNet11
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "Q Lower",
                PacketNumber = 16,
                NetValue = false,
                FormId = 333,
                PacketIndex = 4 * 14,
                MainIndex = 20011,
                PacketSubIndex = 1,
            });
            // MntbNet12
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "VAR_MD",
                PacketNumber = 17,
                NetValue = false,
                FormId = 333,
                PacketIndex = 4 * 14,
                MainIndex = 20012,
                PacketSubIndex = 2,
            });
            // MntbNet13
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "PF_MD",
                PacketNumber = 18,
                NetValue = false,
                FormId = 333,
                PacketIndex = 4 * 14,
                MainIndex = 20013,
                PacketSubIndex = 3,
            });
            //        // MntbNet9
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet9",
            //            PacketNumber = 18,
            //            NetValue = 0,
            //            FormId = 333,
            //            PacketIndex = 4 * 17,
            //            MainIndex = 30009,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            //        // Mnte2Net0
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "Mnte2Net0",
            //            PacketNumber = 18,
            //            NetValue = 0,
            //            FormId = 333,
            //            PacketIndex = 4 * 17,
            //            MainIndex = 30000,
            //            PacketSubIndex = 5,
            //            SubIndexLength = 2,
            //            Items = new List<string>()
            // {
            //    "AVR" ,
            //    "FCR" ,
            //    "VAr" ,
            //    "PF" ,
            //},
            //        });
            #endregion
            #region ' 34 '
            // SetrNet170
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 1,
                Resolution = .001m,
                Unit = "Per Sec.",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Loading Rate",
                PacketNumber = 1,
                NetValue = .01m,
                FormId = 341,
                PacketIndex = 4 * 0,
                MainIndex = 10170,
            });
            // SetrNet128
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Power Factor  Feedback Filter Time",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 341,
                PacketIndex = 4 * 3,
                MainIndex = 10128,
            });
            // SetrNet171
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .001m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Interval Limit (L)",
                PacketNumber = 3,
                NetValue = 0.01m,
                FormId = 341,
                PacketIndex = 4 * 1,
                MainIndex = 10171,
            });
            // SetrNet172
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .001m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Hysteresis (HY)",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 341,
                PacketIndex = 4 * 2,
                MainIndex = 10172,
            });

            // SetrNet129
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .001m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Average Interval Value (M)",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 341,
                PacketIndex = 4 * 4,
                MainIndex = 10129,
            });
            // MntrNet64
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 5,
                MainIndex = 10064,
            });
            // MntrNet65
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Current",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 6,
                MainIndex = 10065,
            });
            // MntrNet66
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 7,
                MainIndex = 10066,
            });
            // MntrNet67
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 8,
                MainIndex = 10067,
            });
            // MntrNet68
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 9,
                MainIndex = 10068,
            });
            // MntrNet69
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "Hz",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Frequency",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 10,
                MainIndex = 10069,
            });
            // MntbNet14
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "52G",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 13,
                MainIndex = 30009,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close" ,
                    "Open" ,
                },
            });
            // MntrNet70
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Q Setpoint",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 11,
                MainIndex = 10070,
            });
            // MntrNet71
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "PF Setpoint",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 342,
                PacketIndex = 4 * 12,
                MainIndex = 10071,
            });
            //// MntrNet72
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet72",
            //    PacketNumber = 14,
            //    NetValue = 0,
            //    FormId = 342,
            //    PacketIndex = 4 * 13,
            //    MainIndex = 10072,
            //});
            //// MntrNet73
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet73",
            //    PacketNumber = 15,
            //    NetValue = 0,
            //    FormId = 342,
            //    PacketIndex = 4 * 14,
            //    MainIndex = 10073,
            //});
            // MntbNet15
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "VAR_MD",
                PacketNumber = 15,
                NetValue = false,
                FormId = 342,
                PacketIndex = 4 * 13,
                MainIndex = 20010,
                PacketSubIndex = 1,
            });
            // MntbNet16
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "PF_MD",
                PacketNumber = 16,
                NetValue = false,
                FormId = 342,
                PacketIndex = 4 * 13,
                MainIndex = 20011,
                PacketSubIndex = 2,
            });
            // MntbNet17
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "PF Raise",
                PacketNumber = 17,
                NetValue = false,
                FormId = 342,
                PacketIndex = 4 * 13,
                MainIndex = 20012,
                PacketSubIndex = 3,
            });
            // MntbNet18
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "PF Lower",
                PacketNumber = 18,
                NetValue = false,
                FormId = 342,
                PacketIndex = 4 * 13,
                MainIndex = 20013,
                PacketSubIndex = 4,
            });


            #endregion
            #region ' 41 '
            // SetbNet14
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "UEL Activation",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 411,
                PacketIndex = 4 * 0,
                MainIndex = 20014,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetbNet15
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "OEL Activation",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 411,
                PacketIndex = 4 * 0,
                MainIndex = 20015,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetbNet16
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "SCL Activation",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 411,
                PacketIndex = 4 * 0,
                MainIndex = 20016,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetbNet17
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "V/F Activation",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 411,
                PacketIndex = 4 * 0,
                MainIndex = 20017,
                PacketSubIndex = 3,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // AC_CNTR
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ACT_CNTR",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 412,
                PacketIndex = 4 * 6,
                PacketSubIndex = 0,
                SubIndexLength = 3,
                Items = new List<string>()
                {
                    "AVR","FCR","Var","PF","UEL","OEL","SCL","V/F"
                },
            });
            // IFR
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IFRef",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 412,
                PacketIndex = 4 * 1,
            });
            // AVOUT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Out",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 412,
                PacketIndex = 4 * 2,
            });
            // OLOUT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "OEL Out",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 412,
                PacketIndex = 4 * 3,
            });
            // ULOUT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "UEL Out",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 412,
                PacketIndex = 4 * 4,
            });
            // VOUT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "VF out",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 412,
                PacketIndex = 4 * 5,
            });
         
            #endregion
            #region ' 42 '
            // SetrNet130
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "SetrNet130",
                PacketNumber = 1,
                NetValue = 5,
                FormId = 421,
                PacketIndex = 4 * 0,
                MainIndex = 10130,
            });
            // SetrNet131
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Active Power Filter Time",
                PacketNumber = 2,
                NetValue = 5,
                FormId = 421,
                PacketIndex = 4 * 1,
                MainIndex = 10131,
            });
            // SetrNet132
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Reactive Power Filter Time",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 421,
                PacketIndex = 4 * 2,
                MainIndex = 10132,
            });
            // SetrNet173
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Kp-Proportional Gain",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 422,
                PacketIndex = 4 * 3,
                MainIndex = 10173,
            });
            // SetrNet174
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ti- Integral Time",
                PacketNumber = 5,
                NetValue = 1,
                FormId = 422,
                PacketIndex = 4 * 4,
                MainIndex = 10174,
            });
            // SetrNet175
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 6,
                NetValue = 161,
                FormId = 422,
                PacketIndex = 4 * 5,
                MainIndex = 10175,
            });
            // SetrNet176
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 7,
                NetValue = 0.2m,
                FormId = 422,
                PacketIndex = 4 * 6,
                MainIndex = 10176,
            });
            // SetrNet133
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "P1",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 423,
                PacketIndex = 4 * 7,
                MainIndex = 10133,
            });
            // SetrNet134
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "P2",
                PacketNumber = 9,
                NetValue = 50,
                FormId = 423,
                PacketIndex = 4 * 8,
                MainIndex = 10134,
            });
            // SetrNet135
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "P3",
                PacketNumber = 10,
                NetValue = 80,
                FormId = 423,
                PacketIndex = 4 * 9,
                MainIndex = 10135,
            });
            // SetrNet136
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "P4",
                PacketNumber = 11,
                NetValue = 100,
                FormId = 423,
                PacketIndex = 4 * 10,
                MainIndex = 10136,
            });
            // SetrNet137
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "P5",
                PacketNumber = 12,
                NetValue = 160,
                FormId = 423,
                PacketIndex = 4 * 11,
                MainIndex = 10137,
            });
            // SetrNet138
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -200,
                Max = 0,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Q1",
                PacketNumber = 13,
                NetValue = -50,
                FormId = 424,
                PacketIndex = 4 * 12,
                MainIndex = 10138,
            });
            // SetrNet139
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -200,
                Max = 0,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Q2",
                PacketNumber = 14,
                NetValue = -40,
                FormId = 424,
                PacketIndex = 4 * 13,
                MainIndex = 10139,
            });
            // SetrNet140
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -200,
                Max = 0,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Q3",
                PacketNumber = 15,
                NetValue = -30,
                FormId = 424,
                PacketIndex = 4 * 14,
                MainIndex = 10140,
            });
            // SetrNet141
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -200,
                Max = 0,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Q4",
                PacketNumber = 16,
                NetValue = -10,
                FormId = 424,
                PacketIndex = 4 * 15,
                MainIndex = 10141,
            });
            // SetrNet142
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -200,
                Max = 0,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Q5",
                PacketNumber = 17,
                NetValue = 0,
                FormId = 424,
                PacketIndex = 4 * 16,
                MainIndex = 10142,
            });
            // SetrNet177
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "UEL Coefficient",
                PacketNumber = 18,
                NetValue = 100,
                FormId = 425,
                PacketIndex = 4 * 17,
                MainIndex = 10177,
            });
            // MntrNet74
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 19,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 18,
                MainIndex = 10074,
            });
            // MntrNet75
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Current",
                PacketNumber = 20,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 19,
                MainIndex = 10075,
            });
            // MntrNet76
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 21,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 20,
                MainIndex = 10076,
            });
            // MntrNet77
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 22,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 21,
                MainIndex = 10077,
            });
            // MntrNet78
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 23,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 22,
                MainIndex = 10078,
            });
            // MntrNet79
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "Hz",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "UEL Ref",
                PacketNumber = 24,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 23,
                MainIndex = 10079,
            });
            // AVO
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Out",
                PacketNumber = 25,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 24,
                MainIndex = 10079,
            });
            // MntrNet80
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "UEL Ref",
                PacketNumber = 26,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 25,
                MainIndex = 10080,
            });
            // MntrNet81
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "UEL Out",
                PacketNumber = 27,
                NetValue = 0,
                FormId = 426,
                PacketIndex = 4 * 26,
                MainIndex = 10081,
            });

            #endregion
            #region ' 43 '
            // SetrNet178
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Maximum Ceiling Current",
                PacketNumber = 1,
                NetValue = 160,
                FormId = 431,
                PacketIndex = 4 * 0,
                MainIndex = 10178,
            });
            // SetrNet143
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Maximum Operation Current",
                PacketNumber = 2,
                NetValue = 100,
                FormId = 431,
                PacketIndex = 4 * 1,
                MainIndex = 10143,
            });
            // SetrNet144
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 20,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Hysteresis interval Limit (L)",
                PacketNumber = 3,
                NetValue = 3,
                FormId = 431,
                PacketIndex = 4 * 2,
                MainIndex = 10144,
            });
            // SetrNet179
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 50,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Operational Time Delay",
                PacketNumber = 4,
                NetValue = 10,
                FormId = 431,
                PacketIndex = 4 * 3,
                MainIndex = 10179,
            });
            // SetrNet180
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 2000,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Cooling Time",
                PacketNumber = 5,
                NetValue = 900,
                FormId = 431,
                PacketIndex = 4 * 4,
                MainIndex = 10180,
            });

            // MntrNet82
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 5,
                MainIndex = 10082,
            });
            // MntrNet83
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Current",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 6,
                MainIndex = 10083,
            });
            // MntrNet84
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 7,
                MainIndex = 10084,
            });
            // MntrNet85
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MVAr",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Reactive Power",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 8,
                MainIndex = 10085,
            });
            // MntrNet86
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Power Factor",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 9,
                MainIndex = 10086,
            });
            // MntrNet87
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "Hz",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Frequency",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 10,
                MainIndex = 10087,
            });
            // AVO
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "52G",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 11,
                MainIndex = 10088,
            });
            // MntrNet88
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "OEL Out",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 432,
                PacketIndex = 4 * 12,
                MainIndex = 10088,
            });

            #endregion
            #region ' 44 '
            // SetrNet145
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Current Filter Time",
                PacketNumber = 1,
                NetValue = 1,
                FormId = 441,
                PacketIndex = 4 * 0,
                MainIndex = 10145,
            });
            // SetrNet146
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Reactive Power Filter Time",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 441,
                PacketIndex = 4 * 1,
                MainIndex = 10146,
            });
            // SetrNet181
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Interval Limit (L)",
                PacketNumber = 3,
                NetValue = 0.5m,
                FormId = 442,
                PacketIndex = 4 * 2,
                MainIndex = 10181,
            });
            // SetrNet182
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Hysteresis (HY)",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 442,
                PacketIndex = 4 * 3,
                MainIndex = 10182,
            });
            // SetrNet147
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Reactive Power Pickup",
                PacketNumber = 5,
                NetValue = 20,
                FormId = 443,
                PacketIndex = 4 * 4,
                MainIndex = 10147,
            });
            // SetrNet183
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Stator Current Pickup",
                PacketNumber = 6,
                NetValue = 100,
                FormId = 443,
                PacketIndex = 4 * 5,
                MainIndex = 10183,
            });
            // MntrNet89
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 444,
                PacketIndex = 4 * 6,
                MainIndex = 10089,
            });
            // MntrNet90
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Current",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 444,
                PacketIndex = 4 * 7,
                MainIndex = 10090,
            });
            // MntrNet91
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Active Power",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 444,
                PacketIndex = 4 * 8,
                MainIndex = 10091,
            });
            //        // MntrNet92
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "MVAr",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet92",
            //            PacketNumber = 10,
            //            NetValue = 0,
            //            FormId = 444,
            //            PacketIndex = 4 * 9,
            //            MainIndex = 10092,
            //        });
            //        // MntrNet93
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet93",
            //            PacketNumber = 11,
            //            NetValue = 0,
            //            FormId = 444,
            //            PacketIndex = 4 * 10,
            //            MainIndex = 10093,
            //        });
            //        // MntrNet94
            //        AllParams.Add(new RealVariable()
            //        {
            //            HasMinMax = false,
            //            Resolution = 1,
            //            Unit = "Hz",
            //            CanChangeInRunMode = true,
            //            IsReadOnly = true,
            //            Label = "MntrNet94",
            //            PacketNumber = 12,
            //            NetValue = 0,
            //            FormId = 444,
            //            PacketIndex = 4 * 11,
            //            MainIndex = 10094,
            //        });
            //        // MntbNet21
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet21",
            //            PacketNumber = 13,
            //            NetValue = 0,
            //            FormId = 444,
            //            PacketIndex = 4 * 12,
            //            MainIndex = 30021,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            // MntbNet22
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "SCL State",
                PacketNumber = 10,
                NetValue = false,
                FormId = 444,
                PacketIndex = 4 * 9,
                MainIndex = 20022,
                PacketSubIndex = 0,
            });
            // MntbNet23
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "SCL Raise",
                PacketNumber = 11,
                NetValue = false,
                FormId = 444,
                PacketIndex = 4 * 9,
                MainIndex = 20023,
                PacketSubIndex = 1,
            });
            // MntbNet24
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "SCL Lower",
                PacketNumber = 12,
                NetValue = false,
                FormId = 444,
                PacketIndex = 4 * 9,
                MainIndex = 20024,
                PacketSubIndex = 2,
            });
            #endregion
            #region ' 45 '
            // SetrNet148
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit",
                PacketNumber = 1,
                NetValue = 20,
                FormId = 451,
                PacketIndex = 4 * 0,
                MainIndex = 10148,
            });
            // SetrNet184
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 2,
                NetValue = 90,
                FormId = 451,
                PacketIndex = 4 * 1,
                MainIndex = 10184,
            });
            // SetrNet185
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Kp-Proportional Gain",
                PacketNumber = 3,
                NetValue = 1,
                FormId = 452,
                PacketIndex = 4 * 2,
                MainIndex = 10185,
            });
            // SetrNet186
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ti- Integral Time",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 452,
                PacketIndex = 4 * 3,
                MainIndex = 10186,
            });
            // SetrNet149
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit On State",
                PacketNumber = 5,
                NetValue = 161,
                FormId = 452,
                PacketIndex = 4 * 4,
                MainIndex = 10149,
            });
            // SetrNet150
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "High Limit Off State",
                PacketNumber = 6,
                NetValue = 161,
                FormId = 452,
                PacketIndex = 4 * 5,
                MainIndex = 10150,
            });
            // SetrNet151
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Low Limit",
                PacketNumber = 7,
                NetValue = 0.3m,
                FormId = 452,
                PacketIndex = 4 * 6,
                MainIndex = 10151,
            });
            // SetrNet187
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 2,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Volt/Hertz Pickup",
                PacketNumber = 8,
                NetValue = 1.06m,
                FormId = 453,
                PacketIndex = 4 * 7,
                MainIndex = 10187,
            });
            // MntrNet95
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 454,
                PacketIndex = 4 * 8,
                MainIndex = 10095,
            });
            // MntrNet96
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KA",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "IFRef",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 454,
                PacketIndex = 4 * 9,
                MainIndex = 10096,
            });
            // MntrNet97
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "MW",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vf set",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 454,
                PacketIndex = 4 * 10,
                MainIndex = 10097,
            });
            //// MntrNet98
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "MVAr",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet98",
            //    PacketNumber = 12,
            //    NetValue = 0,
            //    FormId = 454,
            //    PacketIndex = 4 * 11,
            //    MainIndex = 10098,
            //});
            //// MntrNet99
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet99",
            //    PacketNumber = 13,
            //    NetValue = 0,
            //    FormId = 454,
            //    PacketIndex = 4 * 12,
            //    MainIndex = 10099,
            //});
            // MntrNet100
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "Hz",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Frequency",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 454,
                PacketIndex = 4 * 11,
                MainIndex = 10100,
            });
            // MntrNet101
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "V/F Out",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 454,
                PacketIndex = 4 * 12,
                MainIndex = 10101,
            });
            //        // MntbNet25
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "MntbNet25",
            //            PacketNumber = 16,
            //            NetValue = 0,
            //            FormId = 454,
            //            PacketIndex = 4 * 15,
            //            MainIndex = 30025,
            //            PacketSubIndex = 0,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "Close" ,
            //    "Open" ,
            //},
            //        });
            #endregion
            #region ' 46 '

            // Vt

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vt",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 462,
                PacketIndex = 4 * 0,
            });
            // Is

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Is",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 462,
                PacketIndex = 4 * 1,
            });
            // P
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = " P",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 462,
                PacketIndex = 4 * 2,
            });
            // Q_Ref

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Q_Ref",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 462,
                PacketIndex = 4 * 3,
            });
            // If
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "If",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 462,
                PacketIndex = 4 * 4,
            });
            // AC_CNTR
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ACT_CNTR",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 462,
                PacketIndex = 4 * 5,
                PacketSubIndex = 0,
                SubIndexLength = 3,
                Items = new List<string>()
                {
                    "AVR","FCR","Var","PF","UEL","OEL","SCL","V/F"
                },
            });

            #endregion
            #region ' 51 '
            // Sete2Net16
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Loss Of Field Reaction",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 511,
                PacketIndex = 4 * 0,
                MainIndex = 30016,
                PacketSubIndex = 1,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net17
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Volt/Hertz Reaction",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 511,
                PacketIndex = 4 * 0,
                MainIndex = 30017,
                PacketSubIndex = 3,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net0
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Diode Failure Reaction",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 511,
                PacketIndex = 4 * 0,
                MainIndex = 30000,
                PacketSubIndex = 5,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net13
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Overcurrent Reaction",
                PacketNumber = 5,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30013,
                PacketSubIndex = 7,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });


            // Sete2Net1
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Unbalance Load Reaction",
                PacketNumber = 6,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30001,
                PacketSubIndex = 9,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });

            // Sete2Net3
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Overload Reaction",
                PacketNumber = 7,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30003,
                PacketSubIndex = 11,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net4
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Over Frequency Reaction",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30004,
                PacketSubIndex = 13,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net5
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Under Frequency Reaction",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30005,
                PacketSubIndex = 15,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net6
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Line Over Volt Reaction",
                PacketNumber = 10,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30006,
                PacketSubIndex = 17,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net7
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Vf Over Volt Reaction",
                PacketNumber = 11,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30007,
                PacketSubIndex = 19,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net8
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Phase Fail Reaction",
                PacketNumber = 12,
                NetValue = 2,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30008,
                PacketSubIndex = 21,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net9
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "CT Polarity Reaction",
                PacketNumber = 13,
                NetValue = 2,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30009,
                PacketSubIndex = 23,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net14
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "CT Wire Break Reaction",
                PacketNumber = 14,
                NetValue = 2,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30014,
                PacketSubIndex = 25,
                SubIndexLength = 2,
                Items = new List<string>()
                {
                    "Disable" ,
                    "Alarm" ,
                    "Trip" ,
                },
            });
            // SetbNet1
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thy. Monitor Activation",
                PacketNumber = 1,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 20001,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });
            // Sete2Net10
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Fuse Monitor Reaction",
                PacketNumber = 15,
                NetValue = 2,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30010,
                PacketSubIndex = 27,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Disable" ,
        "Alarm" ,
        "Trip" ,
    },
            });
            // Sete2Net15
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Heat Sink High Temp Reaction",
                PacketNumber = 16,
                NetValue = 1,
                FormId = 512,
                PacketIndex = 4 * 0,
                MainIndex = 30015,
                PacketSubIndex = 29,
                SubIndexLength = 2,
                Items = new List<string>()
                {
                    "Disable" ,
                    "Alarm" ,
                    "Trip" ,
                },
            });
            #endregion
            #region ' 55 '
            // SetrNet63
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 500,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Pickup",
                PacketNumber = 1,
                NetValue = 300,
                FormId = 551,
                PacketIndex = 4 * 0,
                MainIndex = 10063,
            });
            // SetrNet64
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Time Delay",
                PacketNumber = 2,
                NetValue = 200,
                FormId = 551,
                PacketIndex = 4 * 1,
                MainIndex = 10064,
            });
            // SetrNet65
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Pickup",
                PacketNumber = 3,
                NetValue = 35,
                FormId = 552,
                PacketIndex = 4 * 2,
                MainIndex = 10065,
            });
            // SetrNet66
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Time Delay",
                PacketNumber = 4,
                NetValue = 1,
                FormId = 552,
                PacketIndex = 4 * 3,
                MainIndex = 10066,
            });
            // SetrNet27
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Field Current Threshold",
                PacketNumber = 5,
                NetValue = 15,
                FormId = 552,
                PacketIndex = 4 * 4,
                MainIndex = 10027,
            });
            // SetrNet67
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 300,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Pickup",
                PacketNumber = 6,
                NetValue = 105,
                FormId = 553,
                PacketIndex = 4 * 5,
                MainIndex = 10067,
            });
            // SetrNet68
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Thermal Time Constant",
                PacketNumber = 7,
                NetValue = 30,
                FormId = 553,
                PacketIndex = 4 * 6,
                MainIndex = 10068,
            });
            // SetrNet28
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10000,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Cooling Time",
                PacketNumber = 8,
                NetValue = 700,
                FormId = 553,
                PacketIndex = 4 * 7,
                MainIndex = 10028,
            });
            // SetrNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Threshold Value",
                PacketNumber = 9,
                NetValue = 10,
                FormId = 554,
                PacketIndex = 4 * 8,
                MainIndex = 10006,
            });
            // SetrNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Time Delay",
                PacketNumber = 10,
                NetValue = 200,
                FormId = 554,
                PacketIndex = 4 * 9,
                MainIndex = 10007,
            });
            // SetrNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Stability Time",
                PacketNumber = 11,
                NetValue = 400,
                FormId = 554,
                PacketIndex = 4 * 10,
                MainIndex = 10008,
            });
            // SetrNet29
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Over Frequency Pickup",
                PacketNumber = 12,
                NetValue = 130,
                FormId = 555,
                PacketIndex = 4 * 11,
                MainIndex = 10029,
            });
            // SetrNet30
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Over Frequency Time Delay",
                PacketNumber = 13,
                NetValue = 500,
                FormId = 555,
                PacketIndex = 4 * 12,
                MainIndex = 10030,
            });
            // SetrNet31
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Under Frequency Pickup",
                PacketNumber = 14,
                NetValue = 70,
                FormId = 555,
                PacketIndex = 4 * 13,
                MainIndex = 10031,
            });
            // SetrNet32
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Under Frequency Time Delay",
                PacketNumber = 15,
                NetValue = 500,
                FormId = 555,
                PacketIndex = 4 * 14,
                MainIndex = 10032,
            });
            // SetrNet33
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 500,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Line Over Volt Pickup",
                PacketNumber = 16,
                NetValue = 160,
                FormId = 556,
                PacketIndex = 4 * 15,
                MainIndex = 10033,
            });
            // SetrNet34
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Line Over Volt Time Delay",
                PacketNumber = 17,
                NetValue = 500,
                FormId = 556,
                PacketIndex = 4 * 16,
                MainIndex = 10034,
            });
            // SetrNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 500,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "DC Link Over Volt Pickup",
                PacketNumber = 18,
                NetValue = 160,
                FormId = 556,
                PacketIndex = 4 * 17,
                MainIndex = 10003,
            });
            // SetrNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "DC Link Over Volt Time Delay",
                PacketNumber = 19,
                NetValue = 500,
                FormId = 556,
                PacketIndex = 4 * 18,
                MainIndex = 10004,
            });
            // MntrNet102
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vf",
                PacketNumber = 20,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 19,
                MainIndex = 10102,
            });
            // MntrNet103
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vl",
                PacketNumber = 21,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 20,
                MainIndex = 10103,
            });
            // MntrNet104
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "If",
                PacketNumber = 22,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 21,
                MainIndex = 10104,
            });
            // MntrNet105
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "INT_51E",
                PacketNumber = 23,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 22,
                MainIndex = 10105,
            });
            // MntrNet106
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "s",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "T_49E",
                PacketNumber = 24,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 23,
                MainIndex = 10106,
            });
            // MntrNet107
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "s",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "INT_49E",
                PacketNumber = 25,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 24,
                MainIndex = 10107,
            });
            // MntrNet108
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "KV",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Voltage",
                PacketNumber = 26,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 25,
                MainIndex = 10108,
            });
            //// MntrNet109
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "S",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet109",
            //    PacketNumber = 27,
            //    NetValue = 0,
            //    FormId = 557,
            //    PacketIndex = 4 * 26,
            //    MainIndex = 10109,
            //});
            // MntrNet110
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "V",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vd RMS Voltage",
                PacketNumber = 27,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 26,
                MainIndex = 10110,
            });
            // MntrNet111
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "V",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vq RMS Voltage",
                PacketNumber = 28,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 27,
                MainIndex = 10111,
            });
            // MntbNet26
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "Line volt_Detect",
                PacketNumber = 29,
                NetValue = false,
                FormId = 557,
                PacketIndex = 4 * 28,
                MainIndex = 20027,
                PacketSubIndex = 0,
            });
            //// MntbNet27
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet27",
            //    PacketNumber = 31,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20027,
            //    PacketSubIndex = 1,
            //});
            //// MntbNet28
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet28",
            //    PacketNumber = 32,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20028,
            //    PacketSubIndex = 2,
            //});
            //// MntbNet29
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "%",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet29",
            //    PacketNumber = 33,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20029,
            //    PacketSubIndex = 3,
            //});
            //// MntbNet30
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet30",
            //    PacketNumber = 34,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20030,
            //    PacketSubIndex = 4,
            //});
            //// MntbNet31
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet31",
            //    PacketNumber = 35,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20031,
            //    PacketSubIndex = 5,
            //});
            //// MntbNet32
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet32",
            //    PacketNumber = 36,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20032,
            //    PacketSubIndex = 6,
            //});
            //// MntbNet33
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet33",
            //    PacketNumber = 37,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20033,
            //    PacketSubIndex = 7,
            //});
            //// MntbNet34
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet34",
            //    PacketNumber = 38,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20034,
            //    PacketSubIndex = 8,
            //});
            //// MntbNet35
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet35",
            //    PacketNumber = 39,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20035,
            //    PacketSubIndex = 9,
            //});
            //// MntbNet36
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet36",
            //    PacketNumber = 40,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20036,
            //    PacketSubIndex = 10,
            //});
            // MntbNet37
            AllParams.Add(new BoolVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "Phase_Fail",
                PacketNumber = 30,
                NetValue = false,
                FormId = 557,
                PacketIndex = 4 * 28,
                MainIndex = 20037,
                PacketSubIndex = 1,
            });
            // MntbNet38
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "Logic",
                CanChangeInRunMode = false,
                Label = "Phase_Rotation",
                PacketNumber = 31,
                NetValue = 0,
                FormId = 557,
                PacketIndex = 4 * 28,
                MainIndex = 30038,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "ABC" ,
        "ACB" ,
    },
            });
            //// MntbNet39
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet39",
            //    PacketNumber = 43,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20039,
            //    PacketSubIndex = 13,
            //});
            //// MntbNet40
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet40",
            //    PacketNumber = 44,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20040,
            //    PacketSubIndex = 14,
            //});
            //// MntbNet41
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet41",
            //    PacketNumber = 45,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20041,
            //    PacketSubIndex = 15,
            //});
            //// MntbNet42
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet42",
            //    PacketNumber = 46,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20042,
            //    PacketSubIndex = 16,
            //});
            //// MntbNet43
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet43",
            //    PacketNumber = 47,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20043,
            //    PacketSubIndex = 17,
            //});
            //// MntbNet44
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet44",
            //    PacketNumber = 48,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20044,
            //    PacketSubIndex = 18,
            //});
            //// MntbNet45
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet45",
            //    PacketNumber = 49,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20045,
            //    PacketSubIndex = 19,
            //});
            //// MntbNet46
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = true,
            //    Unit = "Logic",
            //    CanChangeInRunMode = false,
            //    Label = "MntbNet46",
            //    PacketNumber = 50,
            //    NetValue = false,
            //    FormId = 557,
            //    PacketIndex = 4 * 29,
            //    MainIndex = 20046,
            //    PacketSubIndex = 20,
            //});
            #endregion
            #region ' 56 '
            // SetrNet152
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "ºC",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Heat Sink Alarm Level",
                PacketNumber = 1,
                NetValue = 80,
                FormId = 561,
                PacketIndex = 4 * 0,
                MainIndex = 10152,
            });
            // SetrNet188
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Heat Sink Trip Level",
                PacketNumber = 2,
                NetValue = 100,
                FormId = 561,
                PacketIndex = 4 * 1,
                MainIndex = 10188,
            });
            // SetrNet153
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "ºC",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Panel Alarm Level",
                PacketNumber = 3,
                NetValue = 50,
                FormId = 561,
                PacketIndex = 4 * 2,
                MainIndex = 10153,
            });
            // SetrNet154
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "ºC",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Coolant Alarm Level",
                PacketNumber = 4,
                NetValue = 50,
                FormId = 561,
                PacketIndex = 4 * 3,
                MainIndex = 10154,
            });

            // SetrNet155
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Vf Filter Time",
                PacketNumber = 5,
                NetValue = 20,
                FormId = 562,
                PacketIndex = 4 * 4,
                MainIndex = 10155,
            });
            // SetrNet156
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "If Filter Time",
                PacketNumber = 6,
                NetValue = 20,
                FormId = 562,
                PacketIndex = 4 * 5,
                MainIndex = 10156,
            });
            // SetrNet189
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -10,
                Max = 0,
                Resolution = .1m,
                Unit = "V",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Brush Droop Voltage",
                PacketNumber = 7,
                NetValue = -5,
                FormId = 562,
                PacketIndex = 4 * 6,
                MainIndex = 10189,
            });
            // SetrNet190
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -10,
                Max = 0,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Brush Current Gain",
                PacketNumber = 8,
                NetValue = -.1m,
                FormId = 562,
                PacketIndex = 4 * 7,
                MainIndex = 10190,
            });
            // SetrNet191
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Rotor Reference Temperature",
                PacketNumber = 9,
                NetValue = 40,
                FormId = 562,
                PacketIndex = 4 * 8,
                MainIndex = 10191,
            });
            // SetrNet192
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = '\u03A9'.ToString(),
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Rotor Reference Resistance",
                PacketNumber = 10,
                NetValue = .13m,
                FormId = 562,
                PacketIndex = 4 * 9,
                MainIndex = 10192,
            });
            // SetrNet193
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Alarm Level",
                PacketNumber = 11,
                NetValue = 120,
                FormId = 562,
                PacketIndex = 4 * 10,
                MainIndex = 10193,
            });
            // SetrNet157
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Generator Time Constant T'do",
                PacketNumber = 12,
                NetValue = 0.7m,
                FormId = 562,
                PacketIndex = 4 * 11,
                MainIndex = 10157,
            });
            // SetrNet158
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Rotor Temp Filter Time",
                PacketNumber = 13,
                NetValue = 50,
                FormId = 562,
                PacketIndex = 4 * 12,
                MainIndex = 10158,
            });
            // Vf
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vf",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 563,
                PacketIndex = 4 * 13,
            });
            // If
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "If",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 563,
                PacketIndex = 4 * 14,
            });
            // RT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "RT",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 563,
                PacketIndex = 4 * 15,
            });
            // BT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 10,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "BT",
                PacketNumber = 17,
                NetValue = 0,
                FormId = 563,
                PacketIndex = 4 * 16,
            });

            #endregion
            #region ' 57 '
            // SetrNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Field Current Threshold",
                PacketNumber = 1,
                NetValue = 5,
                FormId = 571,
                PacketIndex = 4 * 0,
                MainIndex = 10009,
            });
            // SetrNet10
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Time Delay",
                PacketNumber = 2,
                NetValue = 400,
                FormId = 571,
                PacketIndex = 4 * 1,
                MainIndex = 10010,
            });
            // SetrNet11
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Field Current Threshold",
                PacketNumber = 3,
                NetValue = 10,
                FormId = 572,
                PacketIndex = 4 * 2,
                MainIndex = 10011,
            });
            // SetrNet12
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "CT Under Current Pickup",
                PacketNumber = 4,
                NetValue = 3,
                FormId = 572,
                PacketIndex = 4 * 3,
                MainIndex = 10012,
            });
            // SetrNet13
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 999,
                Resolution = 1,
                Unit = "us",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Time Delay",
                PacketNumber = 5,
                NetValue = 250,
                FormId = 572,
                PacketIndex = 4 * 4,
                MainIndex = 10013,
            });
            // SetrNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = false,
                IsReadOnly = false,
                Label = "Monitoring Stop Time",
                PacketNumber = 6,
                NetValue = 2,
                FormId = 572,
                PacketIndex = 4 * 5,
                MainIndex = 10005,
            });
            // SetrNet69
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Field Current Threshold",
                PacketNumber = 7,
                NetValue = 6,
                FormId = 573,
                PacketIndex = 4 * 6,
                MainIndex = 10069,
            });
            // SetrNet70
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "CT Under Current Pickup",
                PacketNumber = 8,
                NetValue = 2,
                FormId = 573,
                PacketIndex = 4 * 7,
                MainIndex = 10070,
            });
            // SetrNet71
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 999,
                Resolution = 1,
                Unit = "ms",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Time Delay",
                PacketNumber = 9,
                NetValue = 2,
                FormId = 573,
                PacketIndex = 4 * 8,
                MainIndex = 10071,
            });
            // SetbNet27
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "External Fuse Monitor",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 574,
                PacketIndex = 4 * 9,
                MainIndex = 20027,
                PacketSubIndex = 3,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "No" ,
                    "Yes" ,
                },
            });
            // SetbNet2
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "External Faul1",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 575,
                PacketIndex = 4 * 9,
                MainIndex = 20002,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetbNet3
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "External Faul2",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 575,
                PacketIndex = 4 * 9,
                MainIndex = 20003,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // SetbNet4
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "External Faul3",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 575,
                PacketIndex = 4 * 9,
                MainIndex = 20004,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // If
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "If",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 10,
            });
            // MntbNet47
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thyristor 1",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30047,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Not Conducted" ,
        "Conducted" ,
    },
            });
            // MntbNet48
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thyristor 2",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30048,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Not Conducted" ,
        "Conducted" ,
    },
            });
            // MntbNet49
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thyristor 3",
                PacketNumber = 17,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30049,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Not Conducted" ,
        "Conducted" ,
    },
            });
            // MntbNet50
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thyristor 4",
                PacketNumber = 18,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30050,
                PacketSubIndex = 3,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Not Conducted" ,
        "Conducted" ,
    },
            });
            // MntbNet51
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thyristor 5",
                PacketNumber = 19,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30051,
                PacketSubIndex = 4,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Not Conducted" ,
        "Conducted" ,
    },
            });
            // MntbNet52
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = false,
                Label = "Thyristor 6",
                PacketNumber = 20,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30052,
                PacketSubIndex = 5,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Not Conducted" ,
        "Conducted" ,
    },
            });
            // MntbNet53
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse Faulty",
                PacketNumber = 21,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30053,
                PacketSubIndex = 6,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet54
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse 1 Failure",
                PacketNumber = 22,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30054,
                PacketSubIndex = 7,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet55
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse 2 Failure",
                PacketNumber = 23,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30055,
                PacketSubIndex = 8,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet56
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse 3 Failure",
                PacketNumber = 24,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30056,
                PacketSubIndex = 9,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet57
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse 4 Failure",
                PacketNumber = 25,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30057,
                PacketSubIndex = 10,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet58
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse 5 Failure",
                PacketNumber = 26,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30058,
                PacketSubIndex = 11,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet59
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fuse 6 Failure",
                PacketNumber = 27,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30059,
                PacketSubIndex = 12,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet60
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Fault",
                PacketNumber = 28,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30060,
                PacketSubIndex = 13,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet61
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Ext Fault 1",
                PacketNumber = 29,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30061,
                PacketSubIndex = 14,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet62
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Ext Fault 2",
                PacketNumber = 30,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30062,
                PacketSubIndex = 15,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            // MntbNet63
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Ext Fault 3",
                PacketNumber = 31,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30063,
                PacketSubIndex = 16,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            //        // MntbNet64
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = true,
            //            Label = "MntbNet64",
            //            PacketNumber = 30,
            //            NetValue = 0,
            //            FormId = 576,
            //            PacketIndex = 4 * 10,
            //            MainIndex = 30064,
            //            PacketSubIndex = 17,
            //            SubIndexLength = 1,
            //            Items = new List<string>()
            // {
            //    "No" ,
            //    "Yes" ,
            //},
            //        });
            // MntbNet65
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Driver Internal Fault",
                PacketNumber = 32,
                NetValue = 0,
                FormId = 576,
                PacketIndex = 4 * 11,
                MainIndex = 30065,
                PacketSubIndex = 17,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "No" ,
        "Yes" ,
    },
            });
            #endregion
            #region ' 61 '
            // SetbNet11
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "PSS Control",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 611,
                PacketIndex = 4 * 3,
                MainIndex = 20011,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
     {
        "Deactive" ,
        "Active" ,
    },
            });
            // SetrNet72
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Power- On Threshold",
                PacketNumber = 1,
                NetValue = 20,
                FormId = 611,
                PacketIndex = 4 * 0,
                MainIndex = 10072,
            });
            // SetrNet73
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = 1,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Power Time Delay",
                PacketNumber = 2,
                NetValue = 5,
                FormId = 611,
                PacketIndex = 4 * 1,
                MainIndex = 10073,
            });
            // SetrNet74
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 200,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Voltage- Off Threshold",
                PacketNumber = 3,
                NetValue = 110,
                FormId = 611,
                PacketIndex = 4 * 2,
                MainIndex = 10074,
            });
            // Sete2Net11
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "PSS Signal",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 611,
                PacketIndex = 4 * 3,
                MainIndex = 30011,
                PacketSubIndex = 1,
                SubIndexLength = 2,
                Items = new List<string>()
     {
        "Power" ,
        "Frequency" ,
        "Derived Speed Deviation" ,
    },
            });
            #endregion
            #region ' 62 '
            // SetrNet75
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Tw1-1st Washout Time",
                PacketNumber = 1,
                NetValue = 10,
                FormId = 621,
                PacketIndex = 4 * 0,
                MainIndex = 10075,
            });
            // SetrNet76
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Tw2-2st Washout Time",
                PacketNumber = 2,
                NetValue = 10,
                FormId = 621,
                PacketIndex = 4 * 1,
                MainIndex = 10076,
            });
            // SetrNet77
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T6- Lowpass Filter Time",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 621,
                PacketIndex = 4 * 2,
                MainIndex = 10077,
            });
            // SetrNet78
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "pu",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Xq-Rotor Freq. Calc.",
                PacketNumber = 4,
                NetValue = 1.84m,
                FormId = 621,
                PacketIndex = 4 * 3,
                MainIndex = 10078,
            });
            // SetrNet79
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Tw3-1st Washout Time",
                PacketNumber = 5,
                NetValue = 10,
                FormId = 622,
                PacketIndex = 4 * 4,
                MainIndex = 10079,
            });
            // SetrNet80
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Tw4-2st Washout Time",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 622,
                PacketIndex = 4 * 5,
                MainIndex = 10080,
            });
            // SetrNet81
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T7- Intergrator Time",
                PacketNumber = 7,
                NetValue = 10,
                FormId = 622,
                PacketIndex = 4 * 6,
                MainIndex = 10081,
            });
            // SetrNet82
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ks3-Power Input Scale",
                PacketNumber = 8,
                NetValue = 1,
                FormId = 622,
                PacketIndex = 4 * 7,
                MainIndex = 10082,
            });
            // SetrNet83
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "MV-s",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "H-Inertia",
                PacketNumber = 9,
                NetValue = 3,
                FormId = 622,
                PacketIndex = 4 * 8,
                MainIndex = 10083,
            });
            // SetrNet84
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Ks1",
                PacketNumber = 10,
                NetValue = 20,
                FormId = 623,
                PacketIndex = 4 * 9,
                MainIndex = 10084,
            });
            // SetrNet85
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Filter Time",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 624,
                PacketIndex = 4 * 10,
                MainIndex = 10085,
            });
            // SetrNet86
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Filter Gain",
                PacketNumber = 12,
                NetValue = 1,
                FormId = 624,
                PacketIndex = 4 * 11,
                MainIndex = 10086,
            });
            // SetrNet87
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T8-Num Time Constant",
                PacketNumber = 13,
                NetValue = .5m,
                FormId = 625,
                PacketIndex = 4 * 12,
                MainIndex = 10087,
            });
            // SetrNet88
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T9-Den Time Constant",
                PacketNumber = 14,
                NetValue = .1m,
                FormId = 625,
                PacketIndex = 4 * 13,
                MainIndex = 10088,
            });
            // SetrNet89
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "N-Num Exp.",
                PacketNumber = 15,
                NetValue = 1,
                FormId = 625,
                PacketIndex = 4 * 14,
                MainIndex = 10089,
            });
            // SetrNet90
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "M-Den Exp.",
                PacketNumber = 16,
                NetValue = 5,
                FormId = 625,
                PacketIndex = 4 * 15,
                MainIndex = 10090,
            });
            // SetrNet91
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T1-1st Time Lead",
                PacketNumber = 17,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 16,
                MainIndex = 10091,
            });
            // SetrNet92
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T2-1st Time Lag",
                PacketNumber = 18,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 17,
                MainIndex = 10092,
            });
            // SetrNet93
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T3-2st Time Lead",
                PacketNumber = 19,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 18,
                MainIndex = 10093,
            });
            // SetrNet94
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T4-2st Time Lag",
                PacketNumber = 20,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 19,
                MainIndex = 10094,
            });
            // SetrNet95
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T10-3st Time Lead",
                PacketNumber = 21,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 20,
                MainIndex = 10095,
            });
            // SetrNet96
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T11-3st Time Lag",
                PacketNumber = 22,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 21,
                MainIndex = 10096,
            });
            // SetrNet97
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T12-4st Time Lead",
                PacketNumber = 23,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 22,
                MainIndex = 10097,
            });
            // SetrNet98
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = .01m,
                Unit = "S",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "T13-4st Time Lag",
                PacketNumber = 24,
                NetValue = .1m,
                FormId = 626,
                PacketIndex = 4 * 23,
                MainIndex = 10098,
            });
            // SetrNet99
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "PSS High limit",
                PacketNumber = 25,
                NetValue = 5,
                FormId = 627,
                PacketIndex = 4 * 24,
                MainIndex = 10099,
            });
            // SetrNet100
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -100,
                Max = 0,
                Resolution = 1,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "PSS Low Limit",
                PacketNumber = 26,
                NetValue = -5,
                FormId = 627,
                PacketIndex = 4 * 25,
                MainIndex = 10100,
            });
            // Vt

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Vt",
                PacketNumber = 27,
                NetValue = 0,
                FormId = 628,
                PacketIndex = 4 * 26,
            });
            // P

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "P",
                PacketNumber = 28,
                NetValue = 0,
                FormId = 628,
                PacketIndex = 4 * 27,
            });
            // F
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "F",
                PacketNumber = 29,
                NetValue = 0,
                FormId = 628,
                PacketIndex = 4 * 28,
            });
            // PSO

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "PSS out",
                PacketNumber = 30,
                NetValue = 0,
                FormId = 628,
                PacketIndex = 4 * 29,
            });
            #endregion
            #region ' 71 '
            // SetbNet18
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_START",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20018,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });
            // SetbNet19
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_STOP",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20019,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });
            // SetbNet20
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_VAR",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20020,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });
            // SetbNet21
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_FCR",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20021,
                PacketSubIndex = 3,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });
            // SetbNet22
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_VAR",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20022,
                PacketSubIndex = 4,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });   // SetbNet23
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_PF",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20023,
                PacketSubIndex = 5,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });   // SetbNet24
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_Raise",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20024,
                PacketSubIndex = 6,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });   // SetbNet25
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_Lower",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20025,
                PacketSubIndex = 7,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });   // SetbNet26
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "ES_RST",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 711,
                PacketIndex = 4 * 0,
                MainIndex = 20026,
                PacketSubIndex = 8,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive" ,
                    "Active" ,
                },
            });
            //        // Sete2Net18
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = false,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "Sete2Net18",
            //            PacketNumber = 5,
            //            NetValue = 0,
            //            FormId = 711,
            //            PacketIndex = 4 * 0,
            //            MainIndex = 30018,
            //            PacketSubIndex = 4,
            //            SubIndexLength = 2,
            //            Items = new List<string>()
            // {
            //    "AVR" ,
            //    "FCR" ,
            //    "VAR" ,
            //    "PF" ,
            //},
            //        });
            //// SetbNet19
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = false,
            //    Unit = "",
            //    CanChangeInRunMode = true,
            //    Label = "SetbNet19",
            //    PacketNumber = 2,
            //    NetValue = false,
            //    FormId = 711,
            //    PacketIndex = 4 * 0,
            //    MainIndex = 20019,
            //    PacketSubIndex = 1,
            //});
            //// SetbNet20
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = false,
            //    Unit = "",
            //    CanChangeInRunMode = true,
            //    Label = "SetbNet20",
            //    PacketNumber = 3,
            //    NetValue = false,
            //    FormId = 711,
            //    PacketIndex = 4 * 0,
            //    MainIndex = 20020,
            //    PacketSubIndex = 2,
            //});
            //// SetbNet21
            //AllParams.Add(new BoolVariable()
            //{
            //    IsReadOnly = false,
            //    Unit = "",
            //    CanChangeInRunMode = true,
            //    Label = "SetbNet21",
            //    PacketNumber = 4,
            //    NetValue = false,
            //    FormId = 711,
            //    PacketIndex = 4 * 0,
            //    MainIndex = 20021,
            //    PacketSubIndex = 3,
            //});

            // MntrNet112
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Gen. Voltage",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 1,
                MainIndex = 10112,
            });
            // MntrNet113
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Gen. Current",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 2,
                MainIndex = 10113,
            });
            // MntrNet114
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Gen. Active Power",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 3,
                MainIndex = 10114,
            });
            // MntrNet115
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Gen. Reactive Power",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 4,
                MainIndex = 10115,
            });
            // MntrNet116
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Gen. Power Factor",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 5,
                MainIndex = 10116,
            });
            // MntrNet117
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Gen. Frequency",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 6,
                MainIndex = 10117,
            });
            // MntbNet66
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Exc. Voltage",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 7,
                MainIndex = 10117,
            });
            // MntrNet118
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Exc. Current",
                PacketNumber = 17,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 8,
                MainIndex = 10118,
            });
            // MntrNet119
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Exc. Bridge Temp",
                PacketNumber = 18,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 9,
                MainIndex = 10119,
            });
            // MntrNet120
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "ºC",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Rotor Temp",
                PacketNumber = 19,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 10,
                MainIndex = 10120,
            });
            // MntrNet121
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "EDM Ripple",
                PacketNumber = 20,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 11,
                MainIndex = 10121,
            });
            // MntbNet67
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Bridge Line Voltage",
                PacketNumber = 21,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 12,
                MainIndex = 10121,
            });
            // MntrNet122
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "Deg",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Firing Angle",
                PacketNumber = 22,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 13,
                MainIndex = 10122,
            });
            // MntrNet123
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Bridge A Op. State",
                PacketNumber = 23,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 14,
                MainIndex = 10123,
            });
            // MntrNet124
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "Bridge B Op. State",
                PacketNumber = 24,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 15,
                MainIndex = 10124,
            });
            // MntrNet125
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "52G",
                PacketNumber = 25,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 16,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close" ,
                    "Open" ,
                },
            });
            // MntrNet126
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "41F",
                PacketNumber = 26,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 16,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close" ,
                    "Open" ,
                },
            });
            // MntrNet127
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "86GT",
                PacketNumber = 27,
                NetValue = 0,
                FormId = 712,
                PacketIndex = 4 * 16,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Not Operate",
                    "Operate" ,
                },
            });
            //// MntrNet128
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet128",
            //    PacketNumber = 22,
            //    NetValue = 0,
            //    FormId = 712,
            //    PacketIndex = 4 * 17,
            //    MainIndex = 10128,
            //});
            //// MntrNet129
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet129",
            //    PacketNumber = 23,
            //    NetValue = 0,
            //    FormId = 712,
            //    PacketIndex = 4 * 18,
            //    MainIndex = 10129,
            //});
            //// MntrNet130
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet130",
            //    PacketNumber = 24,
            //    NetValue = 0,
            //    FormId = 712,
            //    PacketIndex = 4 * 19,
            //    MainIndex = 10130,
            //});
            //// MntrNet131
            //AllParams.Add(new RealVariable()
            //{
            //    HasMinMax = false,
            //    Resolution = 1,
            //    Unit = "%",
            //    CanChangeInRunMode = true,
            //    IsReadOnly = true,
            //    Label = "MntrNet131",
            //    PacketNumber = 25,
            //    NetValue = 0,
            //    FormId = 712,
            //    PacketIndex = 4 * 20,
            //    MainIndex = 10131,
            //});


            //        // MntbNet68
            //        AllParams.Add(new BoolVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = true,
            //            Label = "MntbNet68",
            //            PacketNumber = 28,
            //            NetValue = false,
            //            FormId = 712,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 20068,
            //            PacketSubIndex = 2,
            //        });
            //        // Mnte4Net0
            //        AllParams.Add(new EnumVariable()
            //        {
            //            IsReadOnly = true,
            //            Unit = "",
            //            CanChangeInRunMode = false,
            //            Label = "Mnte4Net0",
            //            PacketNumber = 29,
            //            NetValue = 0,
            //            FormId = 712,
            //            PacketIndex = 4 * 21,
            //            MainIndex = 30000,
            //            PacketSubIndex = 3,
            //            SubIndexLength = 4,
            //            Items = new List<string>()
            // {
            //    "AVR" ,
            //    "FCR" ,
            //    "Var" ,
            //    "PF" ,
            //    "UEL" ,
            //    "OEL" ,
            //    "SCL" ,
            //    "V/F" ,
            //},
            //        });
            #endregion
            #region ' 72 '
            // AC_CNTR
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Active controller",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 6,
                PacketSubIndex = 0,
                SubIndexLength = 3,
                Items = new List<string>()
                {
                    "AVR","FCR","Var","PF","UEL","OEL","SCL","V/F"
                },
            });

            // AVOUT

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "AVR Out",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 0,
            });
            // FCOUT

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "FCR Out",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 1,
            });
            // ULOUT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "UEL Out",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 2,
            });
            // OLOUT

            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "OEL Out",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 3,
            });
            // VFOUT
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "V/F Out",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 4,
            });
            // SCState
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "SCL State",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 6,
                PacketSubIndex = 3,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Deactive",
                    "Active"
                },
            });
            // PSO
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                Unit = "%",
                CanChangeInRunMode = true,
                IsReadOnly = true,
                Label = "PSS Out",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 722,
                PacketIndex = 4 * 5,
            });



            #endregion
            #region ' 73 '

            // DI0
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI0",
                PacketNumber = 1,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI1
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI1",
                PacketNumber = 2,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI2
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI2",
                PacketNumber = 3,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 2,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI3
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI3",
                PacketNumber = 4,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 3,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI4
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI4",
                PacketNumber = 5,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 4,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI5
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI5",
                PacketNumber = 6,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 5,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI6
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI6",
                PacketNumber = 7,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 6,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DI7
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DI7",
                PacketNumber = 8,
                NetValue = 0,
                FormId = 732,
                PacketIndex = 4 * 0,
                PacketSubIndex = 7,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Low",
                    "High"
                },
            });
            // DO0
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO0",
                PacketNumber = 9,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 8,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // DO1
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO1",
                PacketNumber = 10,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 9,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // DO2
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO2",
                PacketNumber = 11,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 10,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // DO3
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO3",
                PacketNumber = 12,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 11,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // DO4
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO4",
                PacketNumber = 13,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 12,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // DO5
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO5",
                PacketNumber = 14,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 13,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // DO6
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "DO6",
                PacketNumber = 15,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 14,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });
            // Life Contact
            AllParams.Add(new EnumVariable()
            {
                IsReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Life Contact",
                PacketNumber = 16,
                NetValue = 0,
                FormId = 733,
                PacketIndex = 4 * 0,
                PacketSubIndex = 15,
                SubIndexLength = 1,
                Items = new List<string>()
                {
                    "Close",
                    "Open"
                },
            });

            #endregion

            #region ' Form1 10111'
            // Form2rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 0,
                PacketNumber = 1,
                PacketIndex = 4 * 0,
                FormId = 10111
            });
            // Form2rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 1,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                FormId = 10111
            });
            // Form2rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 2,
                PacketNumber = 3,
                PacketIndex = 4 * 2,
                FormId = 10111
            });
            // Form2rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 3,
                PacketNumber = 4,
                PacketIndex = 4 * 3,
                FormId = 10111
            });
            // Form2rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 4,
                PacketNumber = 5,
                PacketIndex = 4 * 4,
                FormId = 10111
            });
            // Form2rNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 5,
                PacketNumber = 6,
                PacketIndex = 4 * 5,
                FormId = 10111
            });
            // Form2rNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "KW",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 6,
                PacketNumber = 7,
                PacketIndex = 4 * 6,
                FormId = 10111
            });
            // Form2rNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "KW",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 7,
                PacketNumber = 8,
                PacketIndex = 4 * 7,
                FormId = 10111
            });
            // Form2rNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "KW",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 8,
                PacketNumber = 9,
                PacketIndex = 4 * 8,
                FormId = 10111
            });
            // Form2rNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "QVAR",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 9,
                PacketNumber = 10,
                PacketIndex = 4 * 9,
                FormId = 10111
            });
            // Form2rNet10
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "QVAR",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 10,
                PacketNumber = 11,
                PacketIndex = 4 * 10,
                FormId = 10111
            });
            // Form2rNet11
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "QVAR",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 11,
                PacketNumber = 12,
                PacketIndex = 4 * 11,
                FormId = 10111
            });
            // Form2rNet12
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 12,
                PacketNumber = 13,
                PacketIndex = 4 * 12,
                FormId = 10111
            });
            // Form2rNet13
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 13,
                PacketNumber = 14,
                PacketIndex = 4 * 13,
                FormId = 10111
            });
            // Form2rNet14
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 14,
                PacketNumber = 15,
                PacketIndex = 4 * 14,
                FormId = 10111
            });
            // Form2rNet15
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 15,
                PacketNumber = 16,
                PacketIndex = 4 * 15,
                FormId = 10111
            });
            // Form2rNet16
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 16,
                PacketNumber = 17,
                PacketIndex = 4 * 16,
                FormId = 10111
            });
            // Form2rNet17
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 17,
                PacketNumber = 18,
                PacketIndex = 4 * 17,
                FormId = 10111
            });
            // Form2rNet18
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 500,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "Hz",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 18,
                PacketNumber = 19,
                PacketIndex = 4 * 18,
                FormId = 10111
            });
            // Form2rNet19
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "Hz",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 19,
                PacketNumber = 20,
                PacketIndex = 4 * 19,
                FormId = 10111
            });
            // Form2rNet20
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 60,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "Hz",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 20,
                PacketNumber = 21,
                PacketIndex = 4 * 20,
                FormId = 10111
            });
            // Form2rNet21
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1m,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 21,
                PacketNumber = 22,
                PacketIndex = 4 * 21,
                FormId = 10111
            });
            // Form2rNet22
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = -9,
                Max = 9,
                Resolution = .001m,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 22,
                PacketNumber = 23,
                PacketIndex = 4 * 22,
                FormId = 10111
            });
            // Form2rNet23
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 99,
                Resolution = .01m,
                IsReadOnly = false,
                Unit = "S",
                CanChangeInRunMode = true,
                Label = "Form1rNet" + 23,
                PacketNumber = 24,
                PacketIndex = 4 * 23,
                NetValue = 0.1m,
                FormId = 10111
            });
            //ResolutionService.SetResolution(1.865m, .05m);
            // AllParams
            AllParams.Add(new BoolVariable()
            {
                Label = "Form1bNet0",
                IsReadOnly = false,
                CanChangeInRunMode = true,
                Unit = "",
                PacketNumber = 25,
                PacketIndex = 4 * 24,
                PacketSubIndex = 0,
                FormId = 10111
            });
            for (int i = 24; i <= 38; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    IsReadOnly = true,
                    Label = "Form1rNet" + i,
                    PacketNumber = i + 2,
                    PacketIndex = 4 * (i + 1),
                    FormId = 10111
                };
                AllParams.Add(fn);
            }
            // AllParams
            AllParams.Add(new BoolVariable()
            {
                Label = "Form1bNet1",
                IsReadOnly = true,
                Unit = "",
                PacketNumber = 41,
                PacketIndex = 4 * 40,
                PacketSubIndex = 0,
                FormId = 10111
            });
            #endregion
            #region ' Form2 2011X'
            // Form2rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "S",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 0,
                PacketNumber = 1,
                PacketIndex = 4 * 0,
                FormId = 20111,
                NetValue = .3m
            });
            // Form2rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 1,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                FormId = 20111,
            });
            // Form2rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 2,
                PacketNumber = 3,
                PacketIndex = 4 * 2,
                FormId = 20111,
            });
            // Form2rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 3,
                PacketNumber = 4,
                PacketIndex = 4 * 3,
                FormId = 20111,
            });
            // Form2rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 4,
                PacketNumber = 5,
                PacketIndex = 4 * 4,
                FormId = 20111,
            });
            // Form2rNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 5,
                PacketNumber = 6,
                PacketIndex = 4 * 5,
                FormId = 20111,
            });
            // Form2rNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 30,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 6,
                PacketNumber = 7,
                PacketIndex = 4 * 6,
                FormId = 20111,
            });
            // Form2rNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 7,
                PacketNumber = 8,
                PacketIndex = 4 * 7,
                FormId = 20111,
                NetValue = .01m
            });
            // Form2rNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 8,
                PacketNumber = 9,
                PacketIndex = 4 * 8,
                FormId = 20111,
            });
            // Form2rNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 9,
                PacketNumber = 10,
                PacketIndex = 4 * 9,
                FormId = 20111,
            });
            // Form2rNet10
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 30,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 10,
                PacketNumber = 11,
                PacketIndex = 4 * 10,
                FormId = 20111,
            });
            // Form2rNet11
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 11,
                PacketNumber = 12,
                NetValue = .01m,
                PacketIndex = 4 * 11,
                FormId = 20111,
            });
            // Form2rNet12
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 12,
                PacketNumber = 13,
                PacketIndex = 4 * 12,
                FormId = 20111,
            });
            // Form2rNet13
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 13,
                PacketNumber = 14,
                PacketIndex = 4 * 13,
                FormId = 20111,
            });
            // Form2rNet14
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "S",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 14,
                PacketNumber = 15,
                PacketIndex = 4 * 14,
                FormId = 20111,
                NetValue = 5
            });
            // Form2rNet15
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 15,
                PacketNumber = 16,
                PacketIndex = 4 * 15,
                FormId = 20111,
                NetValue = 1
            });
            // Form2rNet16
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 16,
                PacketNumber = 17,
                PacketIndex = 4 * 16,
                FormId = 20111,
            });
            // Form2rNet17
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 20,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 17,
                PacketNumber = 18,
                PacketIndex = 4 * 17,
                FormId = 20111,
            });
            // Form2rNet18
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2rNet" + 18,
                PacketNumber = 19,
                PacketIndex = 4 * 18,
                FormId = 20111,
                NetValue = .01m
            });
            // AllParams
            for (int i = 0; i <= 3; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form2bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 25,
                    PacketIndex = 4 * 24,
                    PacketSubIndex = i,
                    FormId = 20111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 19; i <= 33; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form2rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i - 19 + 31,
                    PacketIndex = 4 * (i - 19 + 25),
                    FormId = 20111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 4; i <= 10; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form2bNet" + i,
                    IsReadOnly = true,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 49,
                    PacketIndex = 4 * 43,
                    PacketSubIndex = i - 4,
                    FormId = 20111,
                };
                AllParams.Add(fn);
            }
            // Form2_1rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2_1rNet" + 0,
                PacketNumber = 20,
                PacketIndex = 4 * 19,
                FormId = 20112,
                NetValue = .3m
            });
            // Form2_1rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2_1rNet" + 1,
                PacketNumber = 21,
                PacketIndex = 4 * 20,
                FormId = 20112,
            });
            // Form2_1rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2_1rNet" + 2,
                PacketNumber = 22,
                PacketIndex = 4 * 21,
                FormId = 20112,
            });
            // Form2_1rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2_1rNet" + 3,
                PacketNumber = 23,
                PacketIndex = 4 * 22,
                FormId = 20112,
            });
            // Form2_1rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form2_1rNet" + 4,
                PacketNumber = 24,
                PacketIndex = 4 * 23,
                FormId = 20112,
            });
            // AllParams
            for (int i = 0; i <= 1; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form2_1bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 29,
                    PacketIndex = 4 * 24,
                    PacketSubIndex = i + 4,
                    FormId = 20112,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 5; i <= 7; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form2_1rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i - 5 + 46,
                    PacketIndex = 4 * (i - 5 + 40),
                    FormId = 20112,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 2; i <= 2; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form2_1bNet" + i,
                    IsReadOnly = true,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i - 2 + 56,
                    PacketIndex = 4 * 43,
                    PacketSubIndex = i - 2 + 7,
                    FormId = 20112,
                };
                AllParams.Add(fn);
            }
            #endregion
            #region ' Form3 30111'
            // Form3rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 0,
                PacketNumber = 1,
                PacketIndex = 4 * 0,
                FormId = 30111,
            });
            // Form3rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 1,
                PacketNumber = 2,
                NetValue = 0,
                PacketIndex = 4 * 1,
                FormId = 30111,
            });
            // Form3rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 2,
                PacketNumber = 3,
                PacketIndex = 4 * 2,
                FormId = 30111,
            });
            // Form3rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 3,
                PacketNumber = 4,
                PacketIndex = 4 * 3,
                FormId = 30111,
            });
            // Form3rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 4,
                PacketNumber = 5,
                NetValue = 160,
                PacketIndex = 4 * 4,
                FormId = 30111,
            });
            // Form3rNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 5,
                PacketNumber = 6,
                PacketIndex = 4 * 5,
                FormId = 30111,
            });
            // Form3rNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 6,
                PacketNumber = 7,
                PacketIndex = 4 * 6,
                FormId = 30111,
            });
            // Form3rNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 7,
                PacketNumber = 8,
                PacketIndex = 4 * 7,
                FormId = 30111,
            });
            // Form3rNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 8,
                PacketNumber = 9,
                PacketIndex = 4 * 8,
                FormId = 30111,
            });
            // Form3rNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 9,
                PacketNumber = 10,
                NetValue = .74m,
                PacketIndex = 4 * 9,
                FormId = 30111,
            });
            // Form3rNet10
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 10,
                PacketNumber = 11,
                NetValue = 1.111m,
                PacketIndex = 4 * 10,
                FormId = 30111,
            });
            // Form3rNet11
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 11,
                PacketNumber = 12,
                PacketIndex = 4 * 11,
                FormId = 30111,
            });
            // Form3rNet12
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "S",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 12,
                PacketNumber = 13,
                NetValue = .1m,
                PacketIndex = 4 * 12,
                FormId = 30111,
            });
            // Form3rNet13
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 13,
                PacketNumber = 14,
                NetValue = .3m,
                PacketIndex = 4 * 13,
                FormId = 30111,
            });
            // Form3rNet14
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 14,
                PacketNumber = 15,
                PacketIndex = 4 * 14,
                FormId = 30111,
            });
            // Form3rNet15
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 15,
                PacketNumber = 16,
                NetValue = 100,
                PacketIndex = 4 * 15,
                FormId = 30111,
            });
            // Form3rNet16
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 16,
                PacketNumber = 17,
                PacketIndex = 4 * 16,
                FormId = 30111,
            });
            // Form3rNet17
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 17,
                PacketNumber = 18,
                NetValue = .1m,
                PacketIndex = 4 * 17,
                FormId = 30111,
            });
            // Form3rNet18
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 18,
                PacketNumber = 19,
                NetValue = 150,
                PacketIndex = 4 * 18,
                FormId = 30111,
            });
            // Form3rNet19
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form3rNet" + 19,
                PacketNumber = 20,
                NetValue = 30,
                PacketIndex = 4 * 19,
                FormId = 30111,
            });
            // Form3bNet0_3
            for (int i = 0; i <= 5; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form3bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 21,
                    PacketIndex = 4 * 20,
                    PacketSubIndex = i,
                    FormId = 30111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 20; i <= 39; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form3rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i + 2,
                    PacketIndex = 4 * (i - 20 + 21),
                    FormId = 30111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 6; i <= 12; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form3bNet" + i,
                    IsReadOnly = true,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 49,
                    PacketIndex = 4 * 41,
                    PacketSubIndex = i - 6,
                    FormId = 30111,
                };
                AllParams.Add(fn);
            }
            #endregion
            #region ' Form4 4011X'
            // Form4rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form4rNet" + 0,
                PacketNumber = 1,
                NetValue = .3m,
                PacketIndex = 4 * 0,
                FormId = 40111,
            });
            // Form4rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form4rNet" + 1,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                FormId = 40111,
            });
            // Form4rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form4rNet" + 2,
                PacketNumber = 3,
                NetValue = .01m,
                PacketIndex = 4 * 2,
                FormId = 40111,
            });
            // AllParams
            for (int i = 3; i <= 5; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form4rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i - 3 + 10,
                    PacketIndex = 4 * (i - 3 + 9),
                    FormId = 40111,
                };
                AllParams.Add(fn);
            }
            // Form4_1rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form4_1rNet" + 0,
                PacketNumber = 4,
                NetValue = .3m,
                PacketIndex = 4 * 3,
                FormId = 40112,
            });
            // Form4_1rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 9999,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form4_1rNet" + 1,
                PacketNumber = 5,
                PacketIndex = 4 * 4,
                FormId = 40112,
            });
            // Form4_1rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form4_1rNet" + 2,
                PacketNumber = 6,
                NetValue = 30,
                PacketIndex = 4 * 5,
                FormId = 40112,
            });
            // Form4_1rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 101,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "Form4_1rNet" + 3,
                PacketNumber = 7,
                NetValue = 20,
                PacketIndex = 4 * 6,
                FormId = 40112,
            });
            // Form4_1rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "S",
                CanChangeInRunMode = true,
                Label = "Form4_1rNet" + 4,
                PacketNumber = 8,
                NetValue = 1,
                PacketIndex = 4 * 7,
                FormId = 40112,
            });
            // Form2_1bNet0_1
            for (int i = 0; i <= 0; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form4_1bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 9,
                    PacketIndex = 4 * 8,
                    PacketSubIndex = i,
                    FormId = 40112,
                };
                AllParams.Add(fn);
            }
            // Form2_1bNet2_2
            for (int i = 1; i <= 8; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form2_1bNet" + i,
                    IsReadOnly = true,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i - 1 + 13,
                    PacketIndex = 4 * 12,
                    PacketSubIndex = i - 1,
                    FormId = 40112,
                };
                AllParams.Add(fn);
            }
            #endregion
            #region ' Form5 5011X'
            // Form5rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 0,
                PacketNumber = 1,
                PacketIndex = 4 * 0,
                FormId = 50111,
            });
            // Form5rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 1,
                PacketNumber = 2,
                NetValue = 2,
                PacketIndex = 4 * 1,
                FormId = 50111,
            });
            // Form5rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 2,
                PacketNumber = 3,
                NetValue = 10,
                PacketIndex = 4 * 2,
                FormId = 50111,
            });
            // Form5rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 3,
                PacketNumber = 4,
                PacketIndex = 4 * 3,
                FormId = 50111,
            });
            // Form5rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 4,
                PacketNumber = 5,
                PacketIndex = 4 * 4,
                FormId = 50111,
            });
            // Form5rNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 5,
                PacketNumber = 6,
                NetValue = .1m,
                PacketIndex = 4 * 5,
                FormId = 50111,
            });
            // Form5rNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 6,
                PacketNumber = 7,
                PacketIndex = 4 * 6,
                FormId = 50111,
            });
            // Form5rNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 7,
                PacketNumber = 8,
                NetValue = .1m,
                PacketIndex = 4 * 7,
                FormId = 50111,
            });
            // Form5rNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 8,
                PacketNumber = 9,
                PacketIndex = 4 * 8,
                FormId = 50111,
            });
            // Form5rNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 9,
                PacketNumber = 10,
                NetValue = .1m,
                PacketIndex = 4 * 9,
                FormId = 50111,
            });
            // Form5rNet10
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 10,
                PacketNumber = 11,
                PacketIndex = 4 * 10,
                FormId = 50111,
            });
            // Form5rNet11
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 11,
                PacketNumber = 12,
                NetValue = .1m,
                PacketIndex = 4 * 11,
                FormId = 50111,
            });
            // Form5rNet12
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 12,
                PacketNumber = 13,
                PacketIndex = 4 * 12,
                FormId = 50111,
            });
            // Form5rNet13
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 13,
                PacketNumber = 14,
                NetValue = .1m,
                PacketIndex = 4 * 13,
                FormId = 50111,
            });
            // Form5rNet14
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 14,
                PacketNumber = 15,
                NetValue = .3m,
                PacketIndex = 4 * 14,
                FormId = 50111,
            });
            // Form5rNet15
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 15,
                PacketNumber = 16,
                NetValue = .03m,
                PacketIndex = 4 * 15,
                FormId = 50111,
            });
            // Form5rNet16
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 16,
                PacketNumber = 17,
                PacketIndex = 4 * 16,
                FormId = 50111,
            });
            // Form5rNet17
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 17,
                PacketNumber = 18,
                NetValue = .03m,
                PacketIndex = 4 * 17,
                FormId = 50111,
            });
            // Form5rNet18
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 18,
                PacketNumber = 19,
                PacketIndex = 4 * 18,
                FormId = 50111,
            });
            // Form5rNet19
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 19,
                PacketNumber = 20,
                NetValue = .03m,
                PacketIndex = 4 * 19,
                FormId = 50111,
            });
            // Form5rNet20
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 20,
                PacketNumber = 21,
                NetValue = .3m,
                PacketIndex = 4 * 20,
                FormId = 50111,
            });
            // Form5rNet21
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 21,
                PacketNumber = 22,
                NetValue = .03m,
                PacketIndex = 4 * 21,
                FormId = 50111,
            });
            // Form5rNet22
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 22,
                PacketNumber = 23,
                PacketIndex = 4 * 22,
                FormId = 50111,
            });
            // Form5rNet23
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 23,
                PacketNumber = 24,
                NetValue = 1,
                PacketIndex = 4 * 23,
                FormId = 50111,
            });
            // Form5rNet24
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 24,
                PacketNumber = 25,
                PacketIndex = 4 * 24,
                FormId = 50111,
            });
            // Form5rNet25
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 25,
                PacketNumber = 26,
                NetValue = 1,
                PacketIndex = 4 * 25,
                FormId = 50111,
            });
            // Form5rNet26
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 26,
                PacketNumber = 27,
                NetValue = 10,
                PacketIndex = 4 * 26,
                FormId = 50111,
            });
            // Form5rNet27
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 27,
                PacketNumber = 28,
                NetValue = -10,
                PacketIndex = 4 * 27,
                FormId = 50111,
            });
            // Form5rNet28
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form5rNet" + 28,
                PacketNumber = 29,
                PacketIndex = 4 * 28,
                FormId = 50111,
            });
            // Form5bNet0_3
            for (int i = 0; i <= 10; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form5bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 30,
                    PacketIndex = 4 * 29,
                    PacketSubIndex = i,
                    FormId = 50111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 29; i <= 53; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form5rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i - 29 + 41,
                    PacketIndex = 4 * (i - 29 + 30),
                    FormId = 50111,
                };
                AllParams.Add(fn);
            }
            // Form5bNet6_12
            for (int i = 11; i <= 12; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form5bNet" + i,
                    IsReadOnly = true,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i - 11 + 66,
                    PacketIndex = 4 * 55,
                    PacketSubIndex = i - 11,
                    FormId = 50111,
                };
                AllParams.Add(fn);
            }
            #endregion
            #region ' Form6 6011X'
            // Form6rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 0,
                PacketNumber = 1,
                PacketIndex = 4 * 0,
                FormId = 60111,
            });
            // Form6rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 1,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                FormId = 60111,
            });
            // Form6rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 2,
                PacketNumber = 3,
                NetValue = 2,
                PacketIndex = 4 * 2,
                FormId = 60111,
            });
            // Form6rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 3,
                PacketNumber = 4,
                PacketIndex = 4 * 3,
                FormId = 60111,
            });
            // Form6rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 4,
                PacketNumber = 5,
                NetValue = 0.01m,
                PacketIndex = 4 * 4,
                FormId = 60111,
            });
            // Form6rNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 5,
                PacketNumber = 6,
                PacketIndex = 4 * 5,
                FormId = 60111,
            });
            // Form6rNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 6,
                PacketNumber = 7,
                PacketIndex = 4 * 6,
                FormId = 60111,
            });
            // Form6rNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 7,
                PacketNumber = 8,
                PacketIndex = 4 * 7,
                FormId = 60111,
            });
            // Form6rNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 100,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 8,
                PacketNumber = 9,
                NetValue = 6,
                PacketIndex = 4 * 8,
                FormId = 60111,
            });
            // Form6rNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 1000,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "ms",
                CanChangeInRunMode = true,
                Label = "Form6rNet" + 9,
                PacketNumber = 10,
                NetValue = 2,
                PacketIndex = 4 * 9,
                FormId = 60111,
            });
            // AllParams
            for (int i = 0; i <= 1; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form6bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 21,
                    PacketIndex = 4 * 20,
                    PacketSubIndex = i,
                    FormId = 60111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 10; i <= 14; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form6rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i - 10 + 30,
                    PacketIndex = 4 * (i - 10 + 21),
                    FormId = 60111,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 2; i <= 14; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form6bNet" + i,
                    IsReadOnly = true,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i - 2 + 39,
                    PacketIndex = 4 * 30,
                    PacketSubIndex = i - 2,
                    FormId = 60111,
                };
                AllParams.Add(fn);
            }
            // Form6_1rNet0
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 0,
                PacketNumber = 11,
                PacketIndex = 4 * 10,
                FormId = 60112,
            });
            // Form6_1rNet1
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 400,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "%",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 1,
                PacketNumber = 12,
                NetValue = 290,
                PacketIndex = 4 * 11,
                FormId = 60112,
            });
            // Form6_1rNet2
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 2,
                PacketNumber = 13,
                NetValue = 330,
                PacketIndex = 4 * 12,
                FormId = 60112,
            });
            // Form6_1rNet3
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 3,
                PacketNumber = 14,
                PacketIndex = 4 * 13,
                FormId = 60112,
            });
            // Form6_1rNet4
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 4,
                PacketNumber = 15,
                PacketIndex = 4 * 14,
                FormId = 60112,
            });
            // Form6_1rNet5
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 5,
                PacketNumber = 16,
                PacketIndex = 4 * 15,
                FormId = 60112,
            });
            // Form6_1rNet6
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 6,
                PacketNumber = 17,
                PacketIndex = 4 * 16,
                FormId = 60112,
            });
            // Form6_1rNet7
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Max = 9999,
                Min = 0,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "ms",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 7,
                PacketNumber = 18,
                NetValue = 200,
                PacketIndex = 4 * 17,
                FormId = 60112,
            });
            // Form6_1rNet8
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 8,
                PacketNumber = 19,
                PacketIndex = 4 * 18,
                FormId = 60112,
            });
            // Form6_1rNet9
            AllParams.Add(new RealVariable()
            {
                HasMinMax = false,
                Resolution = 0,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "Form6_1rNet" + 9,
                PacketNumber = 20,
                NetValue = 1,
                PacketIndex = 4 * 19,
                FormId = 60112,
            });
            // AllParams
            for (int i = 0; i <= 7; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form6_1bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i + 23,
                    PacketIndex = 4 * 20,
                    PacketSubIndex = i + 2,
                    FormId = 60112,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 10; i <= 13; i++)
            {
                var fn = new RealVariable()
                {
                    HasMinMax = false,
                    Label = "Form6_1rNet" + i,
                    IsReadOnly = true,
                    PacketNumber = i - 10 + 35,
                    PacketIndex = 4 * (i - 10 + 26),
                    FormId = 60112,
                };
                AllParams.Add(fn);
            }
            // AllParams
            for (int i = 8; i <= 14; i++)
            {
                var fn = new BoolVariable()
                {
                    Label = "Form6_1bNet" + i,
                    IsReadOnly = false,
                    CanChangeInRunMode = true,
                    Unit = "",
                    PacketNumber = i - 8 + 52,
                    PacketIndex = 4 * 30,
                    PacketSubIndex = i - 8 + 13,
                    FormId = 60112,
                };
                AllParams.Add(fn);
            }
            #endregion
            #region ' Form7 701XX'
            AllParams.Add(new EnumVariable()
            {
                ReadOnly = false,
                Items = new List<string>() { "0", "1", "2", "3", "4", "5" },
                CanChangeInRunMode = true,
                Label = "Range",
                NetValue = 0,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                PacketSubIndex = 0,
                SubIndexLength = 3,
                FormId = 70111
            });

            AllParams.Add(new RealVariable()
            {
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                PacketNumber = 1,
                NetValue = 3240,
                PacketIndex = 4 * 0,
                FormId = 70111,
                ReadOnly = false,
                Label = "IFN",
                Min = 0,
                Max = 9999,
                HasMinMax = true,
            });
            for (int i = 0; i <= 5; i++)
            {
                AllParams.Add(new RealVariable()
                {
                    HasMinMax = true,
                    Min = 0,
                    Max = 5.6m,
                    Resolution = .1m,
                    IsReadOnly = false,
                    Unit = "V",
                    CanChangeInRunMode = true,
                    Label = "CH" + i,
                    PacketNumber = i + 1,
                    NetValue = 0,
                    PacketIndex = 4 * i,
                    FormId = 70112,
                });
            }

            for (int i = 0; i <= 5; i++)
            {
                AllParams.Add(new RealVariable()
                {
                    Resolution = .1m,
                    IsReadOnly = true,
                    Unit = "",
                    Label = "V" + i,
                    PacketNumber = i + 1,
                    NetValue = 0,
                    PacketIndex = 4 * i,
                    FormId = 70113,
                });
            }

            AllParams.Add(new EnumVariable()
            {
                ReadOnly = false,
                Items = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7" },
                CanChangeInRunMode = true,
                Label = "Range",
                NetValue = 0,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                PacketSubIndex = 0,
                SubIndexLength = 3,
                FormId = 70121
            });

            AllParams.Add(new RealVariable()
            {
                Resolution = .1m,
                IsReadOnly = false,
                Unit = "A",
                CanChangeInRunMode = true,
                PacketNumber = 1,
                NetValue = 3240,
                PacketIndex = 4 * 0,
                FormId = 70121,
                ReadOnly = false,
                Label = "IFN",
                Min = 0,
                Max = 9999,
                HasMinMax = true,
            });
            for (int i = 0; i <= 3; i++)
            {
                AllParams.Add(new RealVariable()
                {
                    HasMinMax = true,
                    Min = 0,
                    Max = .175m * 3240,
                    Resolution = .1m,
                    IsReadOnly = false,
                    Unit = "V",
                    CanChangeInRunMode = true,
                    Label = "CH" + i,
                    PacketNumber = i + 1,
                    NetValue = 0,
                    PacketIndex = 4 * i,
                    FormId = 70122,
                });
            }

            for (int i = 0; i <= 3; i++)
            {
                AllParams.Add(new RealVariable()
                {
                    Resolution = .1m,
                    IsReadOnly = true,
                    Unit = "",
                    Label = "V" + i,
                    PacketNumber = i + 1,
                    NetValue = 0,
                    PacketIndex = 4 * i,
                    FormId = 70123,
                });
            }


            #endregion
            #region ' Form8 801XX' 

            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 24,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "Ma",
                CanChangeInRunMode = true,
                Label = "AI" + 0,
                PacketNumber = 1,
                NetValue = 0,
                PacketIndex = 4 * 0,
                FormId = 80112,
            });

            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 24,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V/Ma",
                CanChangeInRunMode = true,
                Label = "AI" + 1,
                PacketNumber = 2,
                NetValue = 0,
                PacketIndex = 4 * 1,
                FormId = 80112,
            });

            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "AO" + 0,
                PacketNumber = 3,
                NetValue = 0,
                PacketIndex = 4 * 2,
                FormId = 80113,
            });

            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 10,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "V",
                CanChangeInRunMode = true,
                Label = "AO" + 1,
                PacketNumber = 4,
                NetValue = 0,
                PacketIndex = 4 * 3,
                FormId = 80113,
            });

            for (int i = 0; i <= 1; i++)
            {
                AllParams.Add(new RealVariable()
                {
                    Resolution = .1m,
                    IsReadOnly = true,
                    Unit = "",
                    Label = "ADC" + i,
                    PacketNumber = i + 1,
                    NetValue = 0,
                    PacketIndex = 4 * i,
                    FormId = 80114,
                });
            }
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 65536,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "F" + 0,
                PacketNumber = 1,
                NetValue = 0,
                PacketIndex = 4 * 0,
                FormId = 80122,
            });
            AllParams.Add(new EnumVariable()
            {
                ReadOnly = false,
                IsReadOnly = false,
                Items = new List<string>() { "Disable", "Enable" },
                CanChangeInRunMode = true,
                Label = "Select0",
                NetValue = 0,
                PacketNumber = 1,
                PacketIndex = 4 * 0,
                PacketSubIndex = 0,
                SubIndexLength = 1,
                FormId = 80123
            });
            AllParams.Add(new RealVariable()
            {
                HasMinMax = true,
                Min = 0,
                Max = 65536,
                Resolution = 1,
                IsReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                Label = "F" + 1,
                PacketNumber = 2,
                NetValue = 0,
                PacketIndex = 4 * 1,
                FormId = 80122,
            });

            AllParams.Add(new EnumVariable()
            {
                ReadOnly = false,
                Items = new List<string>() { "Disable", "Enable" },
                CanChangeInRunMode = true,
                IsReadOnly = false,
                Label = "Select1",
                NetValue = 0,
                PacketNumber = 2,
                PacketIndex = 4 * 1,
                PacketSubIndex = 1,
                SubIndexLength = 1,
                FormId = 80123
            });
            #endregion

            foreach (var itm in AllParams)
            {
                if (itm.IsReadOnly)
                    itm.Status = VariableStatus.ReadOnly;
                else
                    itm.Status = VariableStatus.Init;
            }

            #endregion

            #region ' Alarms  '

            AllAlarmEvents = new List<AlarmEventVariable>();
            #region ' Alarms '
		
			    AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)0,
                    Message = "Thyristor Bridge A Overcurrent (F60300)",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)1,
                    Message = "DC link overvoltage (F30002)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)2,
                    Message = "Thyristor Bridge A Ground fault (F30021)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)3,
                    Message = "Thyristor Bridge A Line overvoltage (F60007)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)4,
                    Message = "Thyristor Bridge A Line overFrequency (F60008)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)5,
                    Message = "Thyristor Bridge A Line UnderFrequency (F60009)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)6,
                    Message = "Thyristor Bridge A uneven current distribution (F60010)",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)7,
                    Message = "Thyristor Bridge A Phase failure (F60004)",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)8,
                    Message = "Thyristor Bridge A Driver temperature too high (F60090)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)9,
                    Message = "Thyristor Bridge A Temperature Sensor Wire Break or Short Circuit (A60096)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)10,
                    Message = "Thyristor Bridge A Fuse F11 Failure (F60204)",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)11,
                    Message = "Thyristor Bridge A Fuse F12 Failure (F60204)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)12,
                    Message = "Thyristor Bridge A Fuse F13 Failure (F60204)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)13,
                    Message = "Thyristor Bridge A Fuse F14 Failure (F60204)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)14,
                    Message = "Thyristor Bridge A Fuse F15 Failure (F60204)",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)15,
                    Message = "Thyristor Bridge A Fuse F16 Failure (F60204)",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)16,
                    Message = "Thyristor Bridge Driver A Analog input0 Wire Break (A60046)",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)17,
                    Message = "Thyristor 1 Not Conducting",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)18,
                    Message = "Thyristor 2 Not Conducting",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)19,
                    Message = "Thyristor 3 Not Conducting",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)20,
                    Message = "Thyristor 4 Not Conducting",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)21,
                    Message = "Thyristor 5 Not Conducting",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)22,
                    Message = "Thyristor 6 Not Conducting",
                    Type = 1,
                    IsInternal = false
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)23,
                    Message = "DCM External Fault",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)24,
                    Message = "CT Wire Break",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)25,
                    Message = "CT Polarity Fault",
                    Type = 1,
                    IsInternal = false
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)26,
                    Message = "Power check (5V+ feedback)",
                    Type = 4,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)27,
                    Message = "Power check (15V+ feedback)",
                    Type = 4,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)28,
                    Message = "Power check (15V- feedback)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)29,
                    Message = "Power check (Digital Card)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)30,
                    Message = "Power check (24V+ FCR)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)31,
                    Message = "Power check (15V+ FCR)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)32,
                    Message = "Power check (15V- FCR)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)33,
                    Message = "Power check (24V+ Thyristor A)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)34,
                    Message = "Power check (24V+ Thyristor B)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)35,
                    Message = "Power check (5V+ Driver card A)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)36,
                    Message = "Power check (5V+ Driver card B)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)37,
                    Message = "Power check (5V+ FCR)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)38,
                    Message = "Power check (5V+ Shunt)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)39,
                    Message = "Power check (Power meter card)",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)40,
                    Message = "Error on FPGA Connection0 (Data don't received)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)41,
                    Message = "Error on FPGA Connection1 (Data don't received)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)42,
                    Message = "Reference error on bridge voltage",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)43,
                    Message = "Reference error on bridge current",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)44,
                    Message = "Reference error on bridge shunt",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)45,
                    Message = "Short circuit error on bridge voltage (PT)",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)46,
                    Message = "Error on voltage ADC connection",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)47,
                    Message = "Error on CT ADC connection",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)48,
                    Message = "Error on Shunt ADC connection",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)49,
                    Message = "Error on Power meter connection (Data don't received)",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)50,
                    Message = "Reference error on Generator voltage and current",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)51,
                    Message = "Error on ADC connection 1",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)52,
                    Message = "Error on ADC connection 2",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)53,
                    Message = "Error on ADC connection 3",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)54,
                    Message = "Error on ADC connection 4",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)55,
                    Message = "Error on ADC connection 5",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)56,
                    Message = "Error on ADC connection 6",
                    Type = 1,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)57,
                    Message = "Error on Power meter.",
                    Type = 4,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)58,
                    Message = "Error on EEPROM",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)59,
                    Message = "Error on EEPROM volume",
                    Type = 4,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)60,
                    Message = "Error on SD-Card",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)61,
                    Message = "Error on  SD-Card volume",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)62,
                    Message = "Error on  Ethernet PHY",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)63,
                    Message = "Error on CAN Connection (Master and Slave Module)‎",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)64,
                    Message = "Error on Sync Signal Connection  in Bridge Parallel interface (Master Module)‎",
                    Type = 1,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)65,
                    Message = "Error on Sync Signal Connection  in Bridge Parallel interface (Slave Module)‎",
                    Type = 4,
                    IsInternal = true
                });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)66,
                    Message = "Error on Thyristor number in Bridge Parallel interface",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)67,
                    Message = "Driver A  ProfiBus Connection Failure",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)68,
                    Message = "Reference error on NTC",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)69,
                    Message = "Reference error on AI",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)70,
                    Message = "Open or short circuit error on AI0",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)71,
                    Message = "Open or short circuit error on AI1",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)72,
                    Message = "Error on AO0 (Open circuit)",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)73,
                    Message = "Error on AO1 (Open circuit)",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)74,
                    Message = "Error on Feedback output0",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)75,
                    Message = "Error on Feedback output1",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)76,
                    Message = "Error on LCD-Keypad connection",
                    Type = 1,
                    IsInternal = true
                });
				
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)77,
                    Message = "Error on Clock IC connection",
                    Type = 1,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)78,
                    Message = "Status changed Digital in 0",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)79,
                    Message = "Status changed Digital in 1",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)80,
                    Message = "Status changed Digital in 2",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)81,
                    Message = "Status changed Digital in 3",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)82,
                    Message = "Status changed Digital in 4",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)83,
                    Message = "Status changed Digital in 5",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)84,
                    Message = "Status changed Digital in 6",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)85,
                    Message = "Status changed Digital in 7",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)86,
                    Message = "Status changed Digital out 0",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)87,
                    Message = "Status changed Digital out 1",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)88,
                    Message = "Status changed Digital out 2",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)89,
                    Message = "Status changed Digital out 3",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)90,
                    Message = "Status changed Digital out 4",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)91,
                    Message = "Status changed Digital out 5",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)92,
                    Message = "Status changed Digital out 6",
                    Type = 4,
                    IsInternal = true
                });
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)93,
                    Message = "Status changed Digital out 7",
                    Type = 4,
                    IsInternal = true
                });

            #endregion
            #region ' Faults '
		
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)0,
                Message = "Thyristor Bridge A Overcurrent (F60300)",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)1,
                Message = "DC link overvoltage (F30002)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)2,
                Message = "Thyristor Bridge A Ground fault (F30021)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)3,
                Message = "Thyristor Bridge A Line overvoltage (F60007)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)4,
                Message = "Thyristor Bridge A Line overFrequency (F60008)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)5,
                Message = "Thyristor Bridge A Line UnderFrequency (F60009)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)6,
                Message = "Thyristor Bridge A uneven current distribution (F60010)",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)7,
                Message = "Thyristor Bridge A Phase failure (F60004)",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)8,
                Message = "Thyristor Bridge A Driver temperature too high (F60090)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)9,
                Message = "Thyristor Bridge A Temperature Sensor Wire Break or Short Circuit (A60096)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)10,
                Message = "Thyristor Bridge A Fuse F11 Failure (F60204)",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)11,
                Message = "Thyristor Bridge A Fuse F12 Failure (F60204)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)12,
                Message = "Thyristor Bridge A Fuse F13 Failure (F60204)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)13,
                Message = "Thyristor Bridge A Fuse F14 Failure (F60204)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)14,
                Message = "Thyristor Bridge A Fuse F15 Failure (F60204)",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)15,
                Message = "Thyristor Bridge A Fuse F16 Failure (F60204)",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)16,
                Message = "Thyristor Bridge Driver A Analog input0 Wire Break (A60046)",
                Type = 2,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)17,
                Message = "Thyristor 1 Not Conducting",
                Type = 5,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)18,
                Message = "Thyristor 2 Not Conducting",
                Type = 5,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)19,
                Message = "Thyristor 3 Not Conducting",
                Type = 5,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)20,
                Message = "Thyristor 4 Not Conducting",
                Type = 5,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)21,
                Message = "Thyristor 5 Not Conducting",
                Type = 5,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)22,
                Message = "Thyristor 6 Not Conducting",
                Type = 5,
                IsInternal = false
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)23,
                Message = "DCM External Fault",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)24,
                Message = "CT Wire Break",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)25,
                Message = "CT Polarity Fault",
                Type = 2,
                IsInternal = false
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)26,
                Message = "Power check (5V+ feedback)",
                Type = 2,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)27,
                Message = "Power check (15V+ feedback)",
                Type = 2,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)28,
                Message = "Power check (15V- feedback)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)29,
                Message = "Power check (Digital Card)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)30,
                Message = "Power check (24V+ FCR)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)31,
                Message = "Power check (15V+ FCR)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)32,
                Message = "Power check (15V- FCR)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)33,
                Message = "Power check (24V+ Thyristor A)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)34,
                Message = "Power check (24V+ Thyristor B)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)35,
                Message = "Power check (5V+ Driver card A)",
                    Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)36,
                Message = "Power check (5V+ Driver card B)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)37,
                Message = "Power check (5V+ FCR)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)38,
                Message = "Power check (5V+ Shunt)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)39,
                Message = "Power check (Power meter card)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)40,
                Message = "Error on FPGA Connection0 (Data don't received)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)41,
                Message = "Error on FPGA Connection1 (Data don't received)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)42,
                Message = "Reference error on bridge voltage",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)43,
                Message = "Reference error on bridge current",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)44,
                Message = "Reference error on bridge shunt",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)45,
                Message = "Short circuit error on bridge voltage (PT)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)46,
                Message = "Error on voltage ADC connection",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)47,
                Message = "Error on CT ADC connection",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)48,
                Message = "Error on Shunt ADC connection",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)49,
                Message = "Error on Power meter connection (Data don't received)",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)50,
                Message = "Reference error on Generator voltage and current",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)51,
                Message = "Error on ADC connection 1",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)52,
                Message = "Error on ADC connection 2",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)53,
                Message = "Error on ADC connection 3",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)54,
                Message = "Error on ADC connection 4",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)55,
                Message = "Error on ADC connection 5",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)56,
                Message = "Error on ADC connection 6",
                Type = 2,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)57,
                Message = "Error on Power meter.",
                Type = 5,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)58,
                Message = "Error on EEPROM",
                Type = 2,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)59,
                Message = "Error on EEPROM volume",
                Type = 2,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)60,
                Message = "Error on SD-Card",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)61,
                Message = "Error on  SD-Card volume",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)62,
                Message = "Error on  Ethernet PHY",
                Type = 2,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)63,
                Message = "Error on CAN Connection (Master and Slave Module)‎",
                Type = 2,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)64,
                Message = "Error on Sync Signal Connection  in Bridge Parallel interface (Master Module)‎",
                Type = 2,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)65,
                Message = "Error on Sync Signal Connection  in Bridge Parallel interface (Slave Module)‎",
                Type = 2,
                IsInternal = true
            });

            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)66,
                Message = "Error on Thyristor number in Bridge Parallel interface",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)67,
                Message = "Driver A  ProfiBus Connection Failure",
                Type = 2,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)68,
                Message = "Reference error on NTC",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)69,
                Message = "Reference error on AI",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)70,
                Message = "Open or short circuit error on AI0",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)71,
                Message = "Open or short circuit error on AI1",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)72,
                Message = "Error on AO0 (Open circuit)",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)73,
                Message = "Error on AO1 (Open circuit)",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)74,
                Message = "Error on Feedback output0",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)75,
                Message = "Error on Feedback output1",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)76,
                Message = "Error on LCD-Keypad connection",
                Type = 5,
                IsInternal = true
            });


            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)77,
                Message = "Error on Clock IC connection",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)78,
                Message = "Status changed Digital in 0",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)79,
                Message = "Status changed Digital in 1",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)80,
                Message = "Status changed Digital in 2",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)81,
                Message = "Status changed Digital in 3",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)82,
                Message = "Status changed Digital in 4",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)83,
                Message = "Status changed Digital in 5",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)84,
                Message = "Status changed Digital in 6",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)85,
                Message = "Status changed Digital in 7",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)86,
                Message = "Status changed Digital out 0",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)87,
                Message = "Status changed Digital out 1",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)88,
                Message = "Status changed Digital out 2",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)89,
                Message = "Status changed Digital out 3",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)90,
                Message = "Status changed Digital out 4",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)91,
                Message = "Status changed Digital out 5",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)92,
                Message = "Status changed Digital out 6",
                Type = 5,
                IsInternal = true
            });
            AllAlarmEvents.Add(new AlarmEventVariable()
            {
                Code = (ushort)93,
                Message = "Status changed Digital out 7",
                Type = 5,
                IsInternal = true
            });

            #endregion
            #region ' Events '


            AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)94,
                    Message = "state machine event  " ,
                    Type = 3,
                    IsInternal = true
                 });
				
				AllAlarmEvents.Add(new AlarmEventVariable()
                {
                    Code = (ushort)95,
                    Message = "ENET link is up " ,
                    Type = 3,
                    IsInternal = true
                });
            #endregion
            #endregion

            #region ' Trand '

            TrendParams = new List<NetVariable>();
/*             for (int i = 0; i < 39; i++)
            {
                TrendParams.Add(new RealVariable()
                {
                    Label = "P" + (i + 1),
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + i
                });
            }
			 */
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vt [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 0
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vc [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 1
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "P [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 2
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Q [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 3
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Is [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 4
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "F [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 5
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PF [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 6
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "OEL_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 7
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "UEL_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 8
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "VF_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 9
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "AVR_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 10
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "AVR_OutX [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 11
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "FCR_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 12
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "FCR_OutX [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 13
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Pre_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 14
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "AVR_Setpoint [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 15
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "IF_Setpoint [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 16
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Q_Set [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 17
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PF_Set [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 18
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "UEL_Ref [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 19
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Ifref [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 20
                });
            TrendParams.Add(new RealVariable()
            {
                Label = "OP_StateA [%]",
                Unit = "%",
                HasMinMax = true,
                Min = 0,
                Max = 200,
                IsReadOnly = false, // Online Parameter
                MainIndex = 40000 + 21
            });
				 TrendParams.Add(new RealVariable()
                {
                    Label = "OP_StateB [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 22
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "If [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 23
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vf [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 24
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PSS_Out [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 25
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Alpha [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 26
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "DCMfreq [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 27
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Diff_teta [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 28
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vd [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 29
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vq [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 30
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "R_Temp [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 31
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "B_Temp [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 32
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "OverCurrent_Intg [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 33
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "IA_Mean [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 34
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "IB_Mean [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 35
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "IC_Mean [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 36
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vfset [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 37
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Tic_Time [ms]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 200,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 38
                });

            (TrendParams[6] as RealVariable).Min = -100;
            (TrendParams[6] as RealVariable).Max = 100;

            (TrendParams[22] as RealVariable).Max = 100;

            (TrendParams[23] as RealVariable).Max = 100;

            /* for (int i = 39; i < 63; i++)
            {
                TrendParams.Add(new RealVariable()
                {
                    Label = "P" + (i + 1),
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + i
                });
            } */
		     TrendParams.Add(new RealVariable()
                {
                    Label = "41F [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 39
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "52G [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 40
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "86GT [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 41
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "41FT [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 42
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PSS_State [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 43
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Q_72FF [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 44
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Master-DCM [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 45
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Q_Raise [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 46
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Q_Lower [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 47
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PF_Raise [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 48
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PF_Lower [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 49
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "SCL_State [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 50
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "SCL_Raise [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 51
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "SCL_Lower [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 52
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "41FY [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 53
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "FCR_Mode [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 54
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "AVR_Mode [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 55
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "VAR_Mode [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 56
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PF_Mode [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 57
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PM [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 58
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "FPT [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 59
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Vt_Error",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 60
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "PRS",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 61
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "FCR_Force",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = false, // Online Parameter
                    MainIndex = 40000 + 62
                });
/* 
            for (int i = 0; i < 9; i++)
            {
                TrendParams.Add(new RealVariable()
                {
                    Label = "P" + (i + 1),
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + i
                });
            } */
			 TrendParams.Add(new RealVariable()
                {
                    Label = "ScanValue_AB [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 0,
                    PacketIndex = 10100
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "ScanValue_BC [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 1,
                    PacketIndex = 10100
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "ScanValue_CA [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 2,
                    PacketIndex = 10100
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "ScanValue_BX [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 3,
                    PacketIndex = 10100
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "ScanValue_Vf [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 4,
                    PacketIndex = 10100
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "CT_A [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 5,
                    PacketIndex = 7000
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "CT_B [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 6,
                    PacketIndex = 7000
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "CT_C [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 7,
                    PacketIndex = 7000
             });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "If [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = -100,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 8,
                    PacketIndex = 7000
             });
			 
            /* for (int i = 9; i < 15; i++)
            {
                TrendParams.Add(new RealVariable()
                {
                    Label = "P" + (i + 1),
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + i
                });
            } */
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Pulse_T1 [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 9
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Pulse_T2 [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 10
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Pulse_T3 [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 11
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Pulse_T4 [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 12
                });
			 TrendParams.Add(new RealVariable()
                {
                    Label = "Pulse_T5 [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 13
             });
            TrendParams.Add(new RealVariable()
                {
                    Label = "Pulse_T6 [%]",
                    Unit = "%",
                    HasMinMax = true,
                    Min = 0,
                    Max = 100,
                    IsReadOnly = true, // Fast Parameter
                    MainIndex = 50000 + 14
                });
            #endregion
        }
    }
}
