var HtmlReporter = require('protractor-html-screenshot-reporter');
var path = require('path');
var ScreenShotReporter = require('protractor-screenshot-reporter');

 var reporter=new HtmlReporter({
          baseDirectory: '../../report/Clientside-Report/End2endtest/', // a location to store screen shots.
          docTitle: 'Protractor Demo Reporter',
        docName:    'protractor-demo-tests-report.html'
      });
      
exports.config = {
  allScriptsTimeout: 11000,

//seleniumAddress: 'http://localhost:4444/wd/hub',
  specs: [
    './spec/*.js'
  ],

  capabilities: {
    'browserName': 'chrome'
  },

  baseUrl: 'http://localhost:8000/wwwroot/',

  framework: 'jasmine',
  directConnect: true,
 seleniumServerJar: './node_modules/selenium-standalone-jar/bin/selenium-server-standalone-2.47.1.jar',
  jasmineNodeOpts: {
    defaultTimeoutInterval: 30000,
     showColors: true
    
  },
  //  onPrepare: function() {      
  //   require('jasmine-reporters');
  //   jasmine.getEnv().addReporter(
  //     new jasmine.JUnitXmlReporter(null, true, true, './tmp/')
  //   );
  // }

//./e2etest/tmp/
 
   onPrepare: function() {
      // Add a screenshot reporter and store screenshots to `/tmp/screnshots`:
      // jasmine.getEnv().addReporter(new ScreenShotReporter({
      //    baseDirectory: '../../report/Clientside-Report/End2endtest/'
      // }));
      
     

      jasmine.getEnv().addReporter(reporter);
      // Add a screenshot reporter:
      // jasmine.getEnv().addReporter(new HtmlReporter({
      //    baseDirectory: '../../report/Clientside-Report/End2endtest/',
      //    takeScreenShotsOnlyForFailedSpecs: true,
      //    pathBuilder: function pathBuilder(spec, descriptions, results, capabilities) {
          
      //       var monthMap = {
      //         "1": "Jan",
      //         "2": "Feb",
      //         "3": "Mar",
      //         "4": "Apr",
      //         "5": "May",
      //         "6": "Jun",
      //         "7": "Jul",
      //         "8": "Aug",
      //         "9": "Sep",
      //         "10": "Oct",
      //         "11": "Nov",
      //         "12": "Dec"
      //       };

      //       var currentDate = new Date(),
      //           currentHoursIn24Hour = currentDate.getHours(),
      //           currentTimeInHours = currentHoursIn24Hour>12? currentHoursIn24Hour-12: currentHoursIn24Hour,
      //           totalDateString = currentDate.getDate()+'-'+ monthMap[currentDate.getMonth()+1]+ '-'+(currentDate.getYear()+1900) + 
      //                                 '-'+ currentTimeInHours+'h-' + currentDate.getMinutes()+'m';

      //       return path.join(totalDateString,capabilities.caps_.browserName, descriptions.join('-'));
      //    }
      // }));
   }
};
