using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Text;
using BroadMind.Common.Domain;
using BroadMind.Common.Domain.Admin;
using BroadMind.Common.Enumerate;
using BroadMind.DataAccess.Context;
using log4net;

namespace BroadMind.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CollegeContext>
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CollegeContext context)
        {
            #region FinancialAid

            var financialAids = new List<FinancialAid>
            {
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Paul",
                    MiddleName = "Jefferson",
                    LastName = "Bentley",
                    Amount = 2345.89m,
                    Classification = "Junior",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Isaac",
                    MiddleName = "O",
                    LastName = "Oldham",
                    Amount = 2313.64m,
                    Classification = "Freshman",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Mo",
                    MiddleName = "O",
                    LastName = "Banks",
                    Amount = 2613.64m,
                    Classification = "Freshman",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Maurice",
                    MiddleName = "Olufemi",
                    LastName = "Middleton",
                    Amount = 768.29m,
                    Classification = "Senior",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Brian",
                    MiddleName = "Negrone",
                    LastName = "Goode",
                    Amount = null,
                    Classification = string.Empty,
                    OnTrack = false
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Mark",
                    MiddleName = "Nigel",
                    LastName = "Alvarado",
                    Amount = 9854.93m,
                    Classification = "Freshman",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Betty",
                    MiddleName = "Nancy",
                    LastName = "Miner",
                    Amount = 2386.10m,
                    Classification = "Senior",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Maria",
                    MiddleName = "Della",
                    LastName = "Gonzales",
                    Amount = 1238.31m,
                    Classification = "Sophomore",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Martin",
                    MiddleName = "Will",
                    LastName = "Allred",
                    Amount = 2349.50m,
                    Classification = "Sophomore",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Brenda",
                    MiddleName = "Karen",
                    LastName = "Williams",
                    Amount = 3449.53m,
                    Classification = "Sophomore",
                    OnTrack = true
                },
                new FinancialAid
                {
                    FinancialAidId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.FinancialAidSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    FirstName = "Maria",
                    MiddleName = "Cindee",
                    LastName = "Horsefall",
                    Amount = 2271.05m,
                    Classification = "Junior",
                    OnTrack = true
                }
            };

            #endregion FinancialAid

            #region State

            var states = new List<State>
            {
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "AK",
                    StateName = "Alaska",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "AR",
                    StateName = "Arkansas",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "AL",
                    StateName = "Alabama",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "CA",
                    StateName = "California",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "CO",
                    StateName = "Colorado",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "CT",
                    StateName = "Connecticutt",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "DC",
                    StateName = "District of Columbia",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "DE",
                    StateName = "Delaware",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "FL",
                    StateName = "Florida",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "GA",
                    StateName = "Georgia",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "HI",
                    StateName = "Hawaii",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "IA",
                    StateName = "Iowa",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "ID",
                    StateName = "Idaho",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "IL",
                    StateName = "Illinois",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "IN",
                    StateName = "Indiana",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "KS",
                    StateName = "Kansas",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "KY",
                    StateName = "Kentucky",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "LA",
                    StateName = "Louisiana",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MA",
                    StateName = "Massachusetts",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MD",
                    StateName = "Maryland",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "ME",
                    StateName = "Maine",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MI",
                    StateName = "Michigan",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MS",
                    StateName = "Mississippi",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MO",
                    StateName = "Missouri",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MN",
                    StateName = "Minnesota",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "MT",
                    StateName = "Montana",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NC",
                    StateName = "North Carolina",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "ND",
                    StateName = "North Dakota",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NE",
                    StateName = "Nebraska",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NH",
                    StateName = "New Hampshire",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NJ",
                    StateName = "New Jersey",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NM",
                    StateName = "New Mexico",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NV",
                    StateName = "Nevada",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "NY",
                    StateName = "New York",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "OH",
                    StateName = "Ohio",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "OK",
                    StateName = "Oklahoma",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "OR",
                    StateName = "Oregon",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "PA",
                    StateName = "Pennsylvania",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "RI",
                    StateName = "Rhode Island",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "TN",
                    StateName = "Tennessee",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "TX",
                    StateName = "Texas",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "UT",
                    StateName = "Utah",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "VA",
                    StateName = "Virginia",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "WA",
                    StateName = "Washington",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "WI",
                    StateName = "Wisconsin",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "WV",
                    StateName = "West Virginia",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "WY",
                    StateName = "Wyoming",
                    CreatedDate = DateTime.Now
                },
                new State
                {
                    StateId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StateSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    StateCode = "VT",
                    StateName = "Vermont",
                    CreatedDate = DateTime.Now
                }
            };

            #endregion State

            #region Major

            var majors = new List<Major>
            {
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "STAT",
                    MajorDescription = "Statistics",
                    CreatedDate = DateTime.Now
                },
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "ZOOL",
                    MajorDescription = "Zoology",
                    CreatedDate = DateTime.Now
                },
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "BIOCHEM",
                    MajorDescription = "Biochemistry",
                    CreatedDate = DateTime.Now
                },
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "AGRO",
                    MajorDescription = "Agronomy",
                    CreatedDate = DateTime.Now
                },
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "MUSIC",
                    MajorDescription = "Music",
                    CreatedDate = DateTime.Now
                },
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "LAW",
                    MajorDescription = "Law",
                    CreatedDate = DateTime.Now
                },
                new Major
                {
                    MajorId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.MajorSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    MajorName = "PSYCH",
                    MajorDescription = "Psychology",
                    CreatedDate = DateTime.Now
                }
            };

            #endregion Major

            #region Course

            var chem233 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "CHEM 233",
                Description = "Organic Chemistry II",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var chem223 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "CHEM 223",
                Description = "Organic Chemistry I",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var chem103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "CHEM 103",
                Description = "Introductory Chemistry",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var chem333 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "CHEM 333",
                Description = "Quantitative Analysis",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var math103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "MATH 103",
                Description = "Algebra I",
                CreatedDate = DateTime.Now,
                Credit = 5
            };

            var math205 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "MATH 205",
                Description = "Calculus II",
                CreatedDate = DateTime.Now,
                Credit = 5
            };
            var psych205 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "PSYCH 205",
                Description = "Social Psychology",
                CreatedDate = DateTime.Now,
                Credit = 5
            };
            var psych102 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "PSYCH 102",
                Description = "Sports Psychology",
                CreatedDate = DateTime.Now,
                Credit = 2
            };
            var acct103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ACCT 103",
                Description = "Introductory Accounting",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var acct203 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ACCT 203",
                Description = "Tax Accounting",
                CreatedDate = DateTime.Now,
                Credit = 3
            };

            var econ133 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ECON 133",
                Description = "Introductory Economics",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var econ323 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ECON 323",
                Description = "Micro Economics",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var econ223 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ECON 223",
                Description = "Monetary Policy",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var biol203 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "BIOL 203",
                Description = "Plant Ecology",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var biol103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "BIOL 103",
                Description = "Introductory Biology",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var geol213 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "GEOL 213",
                Description = "Introduction to Geology",
                CreatedDate = DateTime.Now,
                Credit = 3
            };

            var engl113 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ENGL 113",
                Description = "English Composition",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var engl223 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ENGL 223",
                Description = "Drama",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var biochem223 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "BIOCHEM 223",
                Description = "Biochemistry of Lipids",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var biochem233 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "BIOCHEM 233",
                Description = "Biochemistry of Proteins",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var finance103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "FIN 103",
                Description = "Introductory Finance",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var microbiol323 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "MICROBIOL 323",
                Description = "Virology",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var market103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "MARKET 103",
                Description = "Commodity markets",
                CreatedDate = DateTime.Now,
                Credit = 5
            };
            var civen203 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "CIVEN 203",
                Description = "Strength of Materials",
                CreatedDate = DateTime.Now,
                Credit = 5
            };

            var agro103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "AGRO 103",
                Description = "Fruits",
                CreatedDate = DateTime.Now,
                Credit = 5
            };
            var educ103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "EDUC 103",
                Description = "Early childhood",
                CreatedDate = DateTime.Now,
                Credit = 2
            };
            var compsi103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "COMPSCI 103",
                Description = "Introduction to computing",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var stat203 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "STAT 203",
                Description = "Statistics for Business",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var music133 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "MUSIC 133",
                Description = "Latin Jazz",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var fineart233 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "FINEART 233",
                Description = "Modern Art",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var archit223 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "ARCHIT 223",
                Description = "Contempary Architecture",
                CreatedDate = DateTime.Now,
                Credit = 3
            };

            var geog203 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "GEOG 203",
                Description = "Geographic Information Systems",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var polsci103 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "POLSCI 103",
                Description = "American Democracy",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var physics213 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "PHYSICS 213",
                Description = "Statics",
                CreatedDate = DateTime.Now,
                Credit = 3
            };

            var mecheng303 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "MECHENG 303",
                Description = "Hydraulic Systems",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var psych343 = new Course
            {
                CourseId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                CourseName = "PSYCH 343",
                Description = "Adolescent Psychology",
                CreatedDate = DateTime.Now,
                Credit = 3
            };
            var courseList = new List<Course>
            {
                acct103,
                acct203,
                agro103,
                archit223,
                biochem223,
                biochem233,
                biol203,
                biol103,
                chem233,
                chem223,
                chem103,
                chem333,
                civen203,
                compsi103,
                econ133,
                econ323,
                econ223,
                educ103,
                engl223,
                engl113,
                finance103,
                fineart233,
                geol213,
                geog203,
                market103,
                microbiol323,
                math103,
                math205,
                mecheng303,
                music133,
                physics213,
                polsci103,
                psych343,
                psych205,
                psych102,
                stat203
            };

            #endregion Course

            #region Address

            var addressZero = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "5653 Main Street",
                Address2 = "Suite 89B",
                City = "Las Vegas",
                StateCode = "NV",
                ZipCode = "90876",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressOne = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "11 Steel Tower",
                Address2 = "",
                City = "Birmingham",
                StateCode = "AL",
                ZipCode = "36454",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressTwo = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "345 Market Street",
                Address2 = "Suite B675",
                City = "Denver",
                StateCode = "CO",
                ZipCode = "76576",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressThree = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "5465 Nixon Lane",
                Address2 = "",
                City = "Atlanta",
                StateCode = "GA",
                ZipCode = "30304",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressFour = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "453 Elm Street",
                Address2 = "",
                City = "San Diego",
                StateCode = "CA",
                ZipCode = "45464",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressFive = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "198 Ohio Way",
                Address2 = "",
                City = "Columbus",
                StateCode = "FL",
                ZipCode = "45464",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressSix = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "564 Lowry Highway",
                Address2 = "",
                City = "Hartford",
                StateCode = "CT",
                ZipCode = "23243",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressSeven = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "7645 Hawkeye Way",
                Address2 = "",
                City = "Iowa City",
                StateCode = "IA",
                ZipCode = "45464",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };

            var addressEight = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "45098 Maui Way",
                Address2 = "",
                City = "Maui",
                StateCode = "HI",
                ZipCode = "56432",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };
            var addressNine = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "4563 Biden Boulevard",
                Address2 = "",
                City = "Dover",
                StateCode = "DE",
                ZipCode = "21345",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };
            var addressTen = new Address
            {
                AddressId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AddressSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                Address1 = "198 Red Auerbach Way",
                Address2 = "",
                City = "Boston",
                StateCode = "MA",
                ZipCode = "10435",
                CreatedDate = DateTime.Now,
                Country = "USA"
            };
            var addresses = new List<Address>
            {
                addressZero,
                addressOne,
                addressTwo,
                addressThree,
                addressFour,
                addressFive,
                addressSix,
                addressSeven,
                addressEight,
                addressNine,
                addressTen
            };

            #endregion Address

            #region Department

            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Economics",
                    DepartmentCode = "ECON",
                    DepartmentDescription = "Economics",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {econ133, econ323, econ223}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Chemistry",
                    DepartmentCode = "CHEM",
                    DepartmentDescription = "Chemistry",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {chem103, chem223, chem233, chem333}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Biochemistry",
                    DepartmentCode = "BIOCHEM",
                    DepartmentDescription = "Biochemistry",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {biochem223, biochem233}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Accounting",
                    DepartmentCode = "ACCT",
                    DepartmentDescription = "Accounting",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {acct103, acct203}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Biology",
                    DepartmentCode = "BIOL",
                    DepartmentDescription = "Biology",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {biol103, biol203}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Microbiology",
                    DepartmentCode = "MICROBIOL",
                    DepartmentDescription = "Microbiology",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {microbiol323}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Finance",
                    DepartmentCode = "FIN",
                    DepartmentDescription = "Finance",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {finance103}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Marketing",
                    DepartmentCode = "MARKET",
                    DepartmentDescription = "Marketing",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {market103}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Civil Engineering",
                    DepartmentCode = "CIVEN",
                    DepartmentDescription = "Civil Engineering",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {civen203}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Agronomy",
                    DepartmentCode = "AGRO",
                    DepartmentDescription = "Agronomy",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {agro103}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Education",
                    DepartmentCode = "EDUC",
                    DepartmentDescription = "Education",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {educ103}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Computer Sciences",
                    DepartmentCode = "COMPSCI",
                    DepartmentDescription = "Computer Sciences",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {compsi103}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Statistics",
                    DepartmentCode = "STAT",
                    DepartmentDescription = "Statistics",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {stat203}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Music",
                    DepartmentCode = "MUSIC",
                    DepartmentDescription = "Music",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {music133}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Fine Arts",
                    DepartmentCode = "FINART",
                    DepartmentDescription = "Fine Arts",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {fineart233}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Architecture",
                    DepartmentCode = "ARCHIT",
                    DepartmentDescription = "Architecture",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {archit223}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Political Science",
                    DepartmentCode = "POLSCI",
                    DepartmentDescription = "Political Science",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {polsci103}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Physics",
                    DepartmentCode = "PHYSICS",
                    DepartmentDescription = "Physics",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {physics213}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Mechanical Engineering",
                    DepartmentCode = "MECHENG",
                    DepartmentDescription = "Mechanical Engineering",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {mecheng303}
                }
                ,
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Psychology",
                    DepartmentCode = "PSYCH",
                    DepartmentDescription = "Psychology",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {psych102, psych205, psych343}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "English",
                    DepartmentCode = "ENGL",
                    DepartmentDescription = "English",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {engl113, engl223}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Geology",
                    DepartmentCode = "GEOL",
                    DepartmentDescription = "Geology",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {geol213}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Geography",
                    DepartmentCode = "GEOG",
                    DepartmentDescription = "Geography",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {geog203}
                },
                new Department
                {
                    DepartmentId =
                        context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.DepartmentSequence;")
                            .FirstOrDefaultAsync()
                            .Result,
                    DepartmentName = "Mathematics",
                    DepartmentCode = "MATH",
                    DepartmentDescription = "Mathematics",
                    CreatedDate = DateTime.Now,
                    Courses = new List<Course> {math103, math205}
                }
            };

            #endregion Department

            #region Student

            var studentZero = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressZero,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "345")
                        .Where(y => y.Prefix == "784")
                        .Where(y => y.LineNumber == "3409")
                        .Where(y => y.Extension == "")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 32,
                Email = "blind@utexas.edu",
                DateOfBirth = DateTime.Parse("12/11/1981"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2012"),
                FirstName = "Brandon",
                MiddleName = "Cruz",
                LastName = "Lind",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Zoology")
            };

            var studentOne = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressOne,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "195")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "4390")
                        .Where(y => y.Extension == "233")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 82,
                Email = "mike.anderson@yahoo.com",
                DateOfBirth = DateTime.Parse("09/23/1989"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2012"),
                FirstName = "Michael",
                MiddleName = "Joel",
                LastName = "Anderson",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Biochemistry")
            };

            var studentTwo = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressOne,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "281")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "8987")
                        .Where(y => y.Extension == "234")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 32,
                Email = "grant.fowler@mailchimp.com",
                DateOfBirth = DateTime.Parse("09/23/1999"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2015"),
                FirstName = "Grant",
                MiddleName = "Garcia",
                LastName = "Fowler",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Psychology")
            };

            var studentThree = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressOne,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "340")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "2945")
                        .Where(y => y.Extension == "10234")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 76,
                Email = "adrianna.margolis@msn.com",
                DateOfBirth = DateTime.Parse("09/23/1999"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2015"),
                FirstName = "Adrianna",
                MiddleName = "Lena",
                LastName = "Margolis",
                Gender = Gender.Female,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Zoology")
            };
            var studentFour = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressOne,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "345")
                        .Where(y => y.Prefix == "784")
                        .Where(y => y.LineNumber == "3409")
                        .Where(y => y.Extension == "")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 7,
                Email = "paige_lena_margolis@ohiostate.edu",
                DateOfBirth = DateTime.Parse("09/23/1977"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2013"),
                FirstName = "Paige",
                MiddleName = "Lena",
                LastName = "Margolis",
                Gender = Gender.Female,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Statistics")
            };
            var studentFive = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressOne,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "405")
                        .Where(y => y.Prefix == "342")
                        .Where(y => y.LineNumber == "4546")
                        .Where(y => y.Extension == "234")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 7,
                Email = "gabriel.larranaga@gmail.com",
                DateOfBirth = DateTime.Parse("09/23/1999"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2015"),
                FirstName = "Gabriel",
                MiddleName = "K",
                LastName = "Larranaga",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Agronomy")
            };
            var studentSix = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressSix,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "430")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "7864")
                        .Where(y => y.Extension == "5464")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 37,
                Email = "brianna.munoz@hotmail.com",
                DateOfBirth = DateTime.Parse("09/23/1999"),
                InitialEnrollmentDate = DateTime.Parse("07/23/2015"),
                FirstName = "Brianna",
                MiddleName = "K",
                LastName = "Munoz",
                Gender = Gender.Female,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Psychology")
            };
            var studentSeven = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressSeven,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "460")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "6753")
                        .Where(y => y.Extension == "321")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 37,
                Email = "lakesha.knight@hotmail.com",
                DateOfBirth = DateTime.Parse("04/11/2001"),
                InitialEnrollmentDate = DateTime.Parse("05/11/2014"),
                FirstName = "Lakesha",
                MiddleName = "K",
                LastName = "Knight",
                Gender = Gender.Female,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Zoology")
            };

            var studentEight = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressEight,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "504")
                        .Where(y => y.Prefix == "388")
                        .Where(y => y.LineNumber == "2434")
                        .Where(y => y.Extension == "234")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 57,
                Email = "paul_marquardt@msn.com",
                DateOfBirth = DateTime.Parse("09/23/1989"),
                InitialEnrollmentDate = DateTime.Parse("04/07/2013"),
                FirstName = "Paul",
                MiddleName = "G",
                LastName = "Marquardt",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Statistics")
            };

            var studentNine = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressEight,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "512")
                        .Where(y => y.Prefix == "234")
                        .Where(y => y.LineNumber == "7653")
                        .Where(y => y.Extension == "234")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 57,
                Email = "kevin.rutherford@msn.com",
                DateOfBirth = DateTime.Parse("09/23/1989"),
                InitialEnrollmentDate = DateTime.Parse("04/07/2013"),
                FirstName = "Kevin",
                MiddleName = "Sam",
                LastName = "Rutherford",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Statistics")
            };
            var studentTen = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressEight,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "800")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "7004")
                        .Where(y => y.Extension == "1665")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 57,
                Email = "mary.y.garcia@msn.com",
                DateOfBirth = DateTime.Parse("09/23/1989"),
                InitialEnrollmentDate = DateTime.Parse("04/07/2013"),
                FirstName = "Mary",
                MiddleName = "Y",
                LastName = "Garcia",
                Gender = Gender.Female,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Statistics")
            };

            var studentEleven = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressEight,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "866")
                        .Where(y => y.Prefix == "873")
                        .Where(y => y.LineNumber == "8731")
                        .Where(y => y.Extension == "6789")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 57,
                Email = "mary.johnson@msn.com",
                DateOfBirth = DateTime.Parse("09/23/1989"),
                InitialEnrollmentDate = DateTime.Parse("04/07/2013"),
                FirstName = "Mary",
                MiddleName = "Y",
                LastName = "Johnson",
                Gender = Gender.Female,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Statistics")
            };
            var studentTwelve = new Student
            {
                StudentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.StudentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Address = addressEight,
                Telephones =
                    context.Telephones.Where(y => y.AreaCode == "877")
                        .Where(y => y.Prefix == "261")
                        .Where(y => y.LineNumber == "9835")
                        .Where(y => y.Extension == "1234")
                        .ToList(),
                CreatedDate = DateTime.Now,
                AccruedCredit = 57,
                Email = "larry.paul.jimenez@msn.com",
                DateOfBirth = DateTime.Parse("09/23/1989"),
                InitialEnrollmentDate = DateTime.Parse("04/07/2013"),
                FirstName = "Larry",
                MiddleName = "Paul",
                LastName = "Jimenez",
                Gender = Gender.Male,
                Major = context.Majors.SingleOrDefault(st => st.MajorName == "Zoology")
            };

            math103.Students = new List<Student> { studentFive, studentSix, studentSeven, studentEight, studentNine };
            engl223.Students = new List<Student> { studentZero, studentOne, studentTwo, studentThree, studentFour };
            civen203.Students = new List<Student> { studentTwelve, studentEight, studentFive, studentOne };
            engl113.Students = new List<Student> { studentNine, studentFive, studentSeven };
            acct103.Students = new List<Student> { studentFive, studentTen, studentTwo, studentThree };
            geog203.Students = new List<Student> { studentNine, studentTen, studentTwo };
            stat203.Students = new List<Student>
            {
                studentTen,
                studentSeven,
                studentFive,
                studentZero,
                studentEight,
                studentEleven,
                studentOne
            };
            math205.Students = new List<Student> { studentZero, studentFive, studentSeven, studentSix };
            studentTwelve.Courses = new List<Course> { civen203, geog203, acct103, math103, finance103, fineart233 };
            studentTwo.Courses = new List<Course> { geol213, stat203, agro103, math205, physics213, psych102 };
            studentThree.Courses = new List<Course> { geog203, stat203, agro103, math205, physics213, psych205 };
            studentEight.Courses = new List<Course>
            {
                agro103,
                chem103,
                biol103,
                physics213,
                engl113,
                market103,
                music133
            };
            studentEight.Courses = new List<Course>
            {
                math205,
                agro103,
                chem103,
                biol103,
                physics213,
                engl113,
                market103,
                music133
            };

            #endregion Student

            #region Enrollment

            var enrollmentZero = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "MATH 205"),
                Students =
                    new List<Student> { studentEight, studentFour, studentTwo, studentSix, studentFive, studentTwelve },
                CreatedDate = DateTime.Now
            };
            var enrollmentOne = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "POLSCI 103"),
                Students = new List<Student> { studentOne, studentTwo, studentThree, studentSix, studentNine },
                CreatedDate = DateTime.Now
            };

            var enrollmentTwo = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "FIN 103"),
                Students = new List<Student> { studentOne, studentFive, studentSeven, studentZero, studentEleven },
                CreatedDate = DateTime.Now
            };

            var enrollmentThree = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "MARKET 103"),
                Students = new List<Student> { studentThree, studentFour, studentSix, studentEight, studentSeven },
                CreatedDate = DateTime.Now
            };

            var enrollmentFour = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "EDUC 103"),
                Students = new List<Student> { studentOne, studentTwo, studentThree, studentFour, studentFive },
                CreatedDate = DateTime.Now
            };

            var enrollmentFive = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "AGRO 103"),
                Students =
                    new List<Student> { studentOne, studentTwo, studentFour, studentEight, studentTen, studentTwelve },
                CreatedDate = DateTime.Now
            };

            var enrollmentSix = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "ACCT 103"),
                Students =
                    new List<Student> { studentThree, studentFive, studentEleven, studentNine, studentTwo, studentTwelve },
                CreatedDate = DateTime.Now
            };

            var enrollmentSeven = new Enrollment
            {
                EnrollmentId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.EnrollmentSequence;")
                    .FirstOrDefaultAsync()
                    .Result,
                Course = context.Courses.SingleOrDefault(st => st.CourseName == "ENGL 113"),
                Students =
                    new List<Student>
                    {
                        studentSix,
                        studentOne,
                        studentThree,
                        studentFive,
                        studentEleven,
                        studentNine,
                        studentTwo,
                        studentTwelve
                    },
                CreatedDate = DateTime.Now
            };

            #endregion Enrollment

            #region Telephone

            var telephones = new List<Telephone>();

            var phoneOneOwner =
                context.Students.Where(y => y.FirstName == "Michael")
                    .Where(y => y.MiddleName == "Joel")
                    .Where(y => y.LastName == "Anderson")
                    .SingleOrDefault(y => y.Email == "mike.anderson@yahoo.com");

            var phoneOne = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "504",
                Prefix = "388",
                LineNumber = "2434",
                Extension = "234",
                PhoneType = PhoneType.Land,
                CreatedDate = DateTime.Now,
                Student = studentOne,
                StudentId = studentOne.StudentId
            };
            telephones.Add(phoneOne);

            var phoneTwoOwner =
                context.Students.Where(y => y.FirstName == "Grant")
                    .Where(y => y.MiddleName == "Garcia")
                    .Where(y => y.LastName == "Fowler")
                    .SingleOrDefault(y => y.Email == "grant.fowler@mailchimp.com");

            var phoneTwo = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "405",
                Prefix = "342",
                LineNumber = "4546",
                Extension = "234",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentTwo,
                StudentId = studentTwo.StudentId
            };
            telephones.Add(phoneTwo);

            var phoneThreeOwner =
                context.Students.Where(y => y.FirstName == "Adrianna")
                    .Where(y => y.MiddleName == "Lena")
                    .Where(y => y.LastName == "Margolis")
                    .SingleOrDefault(y => y.Email == "adrianna.margolis@msn.com");

            var phoneThree = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "281",
                Prefix = "873",
                LineNumber = "8987",
                Extension = "234",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentThree,
                StudentId = studentThree.StudentId
            };
            telephones.Add(phoneThree);

            var phoneFourOwner =
                context.Students.Where(y => y.FirstName == "Paige")
                    .Where(y => y.MiddleName == "Lena")
                    .Where(y => y.LastName == "Margolis")
                    .SingleOrDefault(y => y.Email == "paige_lena_margolis@ohiostate.edu");

            var phoneFour = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "214",
                Prefix = "375",
                LineNumber = "5857",
                Extension = "234",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentFour,
                StudentId = studentFour.StudentId
            };
            telephones.Add(phoneFour);

            var phoneFiveOwner =
                context.Students.Where(y => y.FirstName == "Gabriel")
                    .Where(y => y.MiddleName == "K")
                    .Where(y => y.LastName == "Larranaga")
                    .SingleOrDefault(y => y.Email == "gabriel.larranaga@gmail.com");

            var phoneFive = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "512",
                Prefix = "234",
                LineNumber = "7653",
                Extension = "234",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentFive,
                StudentId = studentFive.StudentId
            };
            telephones.Add(phoneFive);

            var phoneSixOwner =
                context.Students.Where(y => y.FirstName == "Brianna")
                    .Where(y => y.MiddleName == "K")
                    .Where(y => y.LastName == "Munoz")
                    .SingleOrDefault(y => y.Email == "brianna.munoz@hotmail.com");

            var phoneSix = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "877",
                Prefix = "261",
                LineNumber = "9835",
                Extension = "1234",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentSix,
                StudentId = studentSix.StudentId
            };
            telephones.Add(phoneSix);

            var phoneSevenOwner =
                context.Students.Where(y => y.FirstName == "Lakesha")
                    .Where(y => y.MiddleName == "K")
                    .Where(y => y.LastName == "Knight")
                    .SingleOrDefault(y => y.Email == "lakesha.knight@hotmail.com");

            var phoneSeven = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "866",
                Prefix = "873",
                LineNumber = "8731",
                Extension = "6789",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentSeven,
                StudentId = studentSeven.StudentId
            };
            telephones.Add(phoneSeven);


            var phoneEightOwner =
                context.Students.Where(y => y.FirstName == "Paul")
                    .Where(y => y.MiddleName == "G")
                    .Where(y => y.LastName == "Marquardt")
                    .SingleOrDefault(y => y.Email == "paul_marquardt@msn.com");

            var phoneEight = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "460",
                Prefix = "873",
                LineNumber = "6753",
                Extension = "321",
                PhoneType = PhoneType.Land,
                CreatedDate = DateTime.Now,
                Student = studentEight,
                StudentId = studentEight.StudentId
            };
            telephones.Add(phoneEight);


            var phoneNineOwner =
                context.Students.Where(y => y.FirstName == "Kevin")
                    .Where(y => y.MiddleName == "Sam")
                    .Where(y => y.LastName == "Rutherford")
                    .SingleOrDefault(y => y.Email == "kevin.rutherford@msn.com");


            var phoneNine = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "800",
                Prefix = "873",
                LineNumber = "7004",
                Extension = "1665",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentNine,
                StudentId = studentNine.StudentId
            };
            telephones.Add(phoneNine);


            var phoneTenOwner =
                context.Students.Where(y => y.FirstName == "Mary")
                    .Where(y => y.MiddleName == "Y")
                    .Where(y => y.LastName == "Garcia")
                    .SingleOrDefault(y => y.Email == "mary.y.garcia@msn.com");


            var phoneTen = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "195",
                Prefix = "873",
                LineNumber = "4390",
                Extension = "233",
                PhoneType = PhoneType.Land,
                CreatedDate = DateTime.Now,
                Student = studentTen,
                StudentId = studentTen.StudentId
            };
            telephones.Add(phoneTen);

            var phoneElevenOwner =
                context.Students.Where(y => y.FirstName == "Mary")
                    .Where(y => y.MiddleName == "Y")
                    .Where(y => y.LastName == "Johnson")
                    .SingleOrDefault(y => y.Email == "mary.johnson@msn.com");

            var phoneEleven = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "340",
                Prefix = "873",
                LineNumber = "2945",
                Extension = "10234",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentEleven,
                StudentId = studentEleven.StudentId
            };
            telephones.Add(phoneEleven);


            var phoneTwelveOwner =
                context.Students.Where(y => y.FirstName == "Larry")
                    .Where(y => y.MiddleName == "Paul")
                    .Where(y => y.LastName == "Jimenez")
                    .SingleOrDefault(y => y.Email == "larry.paul.jimenez@msn.com");

            var phoneTwelve = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "430",
                Prefix = "873",
                LineNumber = "7864",
                Extension = "5464",
                PhoneType = PhoneType.Land,
                CreatedDate = DateTime.Now,
                Student = studentTwelve,
                StudentId = studentTwelve.StudentId
            };
            telephones.Add(phoneTwelve);


            var phoneZeroOwner =
                context.Students.Where(y => y.FirstName == "Brandon")
                    .Where(y => y.MiddleName == "Cruz")
                    .Where(y => y.LastName == "Lind")
                    .SingleOrDefault(y => y.Email == "blind@utexas.edu");


            var phoneZero = new Telephone
            {
                TelephoneId =
                    context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TelephoneSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                AreaCode = "345",
                Prefix = "784",
                LineNumber = "3409",
                Extension = "",
                PhoneType = PhoneType.Mobile,
                CreatedDate = DateTime.Now,
                Student = studentZero,
                StudentId = studentZero.StudentId
            };

            telephones.Add(phoneZero);

            #endregion Telephone

            studentZero.Enrollments = new List<Enrollment> { enrollmentFive, enrollmentThree, enrollmentZero };
            studentEight.Enrollments = new List<Enrollment> { enrollmentOne, enrollmentThree, enrollmentFour };
            studentOne.Enrollments = new List<Enrollment> { enrollmentFive, enrollmentFour, enrollmentZero };
            studentFive.Enrollments = new List<Enrollment> { enrollmentFive, enrollmentThree, enrollmentZero };
            studentSeven.Enrollments = new List<Enrollment> { enrollmentFour, enrollmentThree, enrollmentZero };
            studentNine.Enrollments = new List<Enrollment> { enrollmentFive, enrollmentThree, enrollmentZero };
            studentSix.Enrollments = new List<Enrollment> { enrollmentTwo, enrollmentOne, enrollmentFive };

            #region Semester

            var semesters = new List<Semester>
            {
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "1998",
                    AcademicYear = "1998/1999",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentOne.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "1999",
                    AcademicYear = "1998/1999",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentOne.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "1999",
                    AcademicYear = "1998/1999",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentOne.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "1999",
                    AcademicYear = "1999/2000",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentTwo.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2000",
                    AcademicYear = "1999/2000",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentTwo.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2000",
                    AcademicYear = "1999/2000",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentTwo.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2000",
                    AcademicYear = "2000/2001",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentThree.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2001",
                    AcademicYear = "2000/2001",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentThree.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2001",
                    AcademicYear = "2000/2001",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentThree.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2001",
                    AcademicYear = "2001/2002",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentFour.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2002",
                    AcademicYear = "2001/2002",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentFour.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2002",
                    AcademicYear = "2001/2002",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentFour.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2002",
                    AcademicYear = "2002/2003",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentFive.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2003",
                    AcademicYear = "2002/2003",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentFive.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2003",
                    AcademicYear = "2002/2003",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentTen.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2003",
                    AcademicYear = "2003/2004",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentSix.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2004",
                    AcademicYear = "2003/2004",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentNine.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2004",
                    AcademicYear = "2003/2004",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentSix.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2004",
                    AcademicYear = "2004/2005",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentTwelve.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2005",
                    AcademicYear = "2004/2005",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentSeven.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2005",
                    AcademicYear = "2004/2005",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentEight.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2005",
                    AcademicYear = "2005/2006",
                    SemesterName = "Fall",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentTen.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2006",
                    AcademicYear = "2005/2006",
                    SemesterName = "Spring",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentEleven.StudentId
                },
                new Semester
                {
                    SemesterId = context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SemesterSequence;")
                        .FirstOrDefaultAsync()
                        .Result,
                    CalendarYear = "2006",
                    AcademicYear = "2005/2006",
                    SemesterName = "Summer",
                    ModifiedBy = null,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    StudentId = studentSix.StudentId
                }
            };

            #endregion Semester

            var students = new List<Student>
            {
                studentOne,
                studentTwo,
                studentThree,
                studentFour,
                studentFive,
                studentSix,
                studentSeven,
                studentEight,
                studentNine,
                studentTen,
                studentEleven,
                studentTwelve
            };
            var enrollments = new List<Enrollment>
            {
                enrollmentZero,
                enrollmentOne,
                enrollmentTwo,
                enrollmentThree,
                enrollmentFour,
                enrollmentFive,
                enrollmentSix,
                enrollmentSeven
            };

            courseList.ForEach(m => { context.Courses.AddOrUpdate(m); });
            states.ForEach(m => { context.States.AddOrUpdate(m); });
            departments.ForEach(m => { context.Departments.AddOrUpdate(m); });
            majors.ForEach(m => { context.Majors.AddOrUpdate(m); });

            telephones.ForEach(m => { context.Telephones.AddOrUpdate(m); });
            addresses.ForEach(m => { context.Addresses.AddOrUpdate(m); });
            students.ForEach(m => { context.Students.AddOrUpdate(m); });
            enrollments.ForEach(m => { context.Enrollments.AddOrUpdate(m); });
            financialAids.ForEach(m => { context.FinancialAids.AddOrUpdate(m); });
            semesters.ForEach(m => { context.Semesters.AddOrUpdate(m); });

            SaveChanges(context);
        }

        private static void SaveChanges(CollegeContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                        Console.WriteLine(sb.ToString());
                        Console.ReadLine();
                        Log.Error(sb.ToString());
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                    );
            }
        }
    }
}