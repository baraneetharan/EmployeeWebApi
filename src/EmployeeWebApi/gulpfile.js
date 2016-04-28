"use strict";

/* Declarations */
var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    protractor = require('gulp-protractor').protractor,
    webdriver_standalone = require('gulp-protractor').webdriver_standalone,
    webdriver_update = require('gulp-protractor').webdriver_update,
    Server = require('karma').Server;
    
var mocha = require('gulp-mocha');
var dnx = dnx = require("gulp-dnx");
var webserver = require('gulp-webserver');
var exec = require('child_process').exec;

var paths = {
    webroot: "./wwwroot/"
};

var itoptions = {
    //cmd: 'dnx test',
    cwd: '../../test/EmployeeWebApiIntegrationTest/',
     watch: false,
   run: false
    
};

var utoptions = {
   
    cwd: '../../test/EmployeeWebApiTest/',
     watch: false,
     run: true,
};

var weboptions = {
     restore: true,
    build: false,
    run: true,
    cwd: './'
}
var angularpath = { Scripts : "./Scripts/"};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";
angularpath.controller = angularpath.Scripts + "Controller/*.js";
angularpath.Service = angularpath.Scripts + "Service/*.js";
angularpath.module = angularpath.Scripts + "app.js";
angularpath.minApp = paths.webroot + "app.js";
angularpath.concatJsDest = paths.webroot + "app.js";
/* End Declaration */

/** CMD : gulp min:apjs 
 * To Minifying app.js 
 */
gulp.task("min:apjs", function () {
    return gulp.src([angularpath.module, angularpath.Service, angularpath.controller], { base: "." })
        .pipe(concat(angularpath.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

/** CMD : gulp unittest 
 * Run Client-side Unittest 
 */
gulp.task('unittest', function (done) {
    new Server({
        configFile: __dirname + '/karma.conf.js',
        singleRun: true
    }, done).start();
});

/** CMD: gulp tdd
 * Run Client-side Unittest
 * Watch for file changes and re-run tests on each change
 */
gulp.task('tdd', function (done) {
    new Server({
        configFile: __dirname + '/karma.conf.js'
    }, done).start();
});

/** CMD : gulp clean:js 
 * To clean(remove) js 
 */
gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

/** CMD : gulp clean:css 
 * To clean css 
 */
gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

/** CMD : gulp min:js 
 * To Minifying js 
 * */
gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

/** CMD : gulp min:css 
 * To Minifying css
 **/
gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

/** CMD : gulp mochatest 
 * Run client-side Integration test
 **/
gulp.task("mochatest", function () {

    return gulp.src('../../test/EmployeeApiTest/spec/*.js', { read: false })
        .pipe(mocha({
            reporter: 'mochawesome',
            reporterOptions: {
                reportDir: '../../report/Clientside-Report/Integrationtest/',
                reportName: 'Report',
                reportTitle: 'EmployeeApiReport',
                inlineAssets: false
            }
        }));
});

/** CMD : gulp webserver 
 * To Start node.js server
 **/
gulp.task('webserver', function() {
    gulp.src('.')
        .pipe(webserver({
            livereload: false,
            directoryListing: true,
            open: "http://localhost:8000/wwwroot/index.html"
        }));
});

/** CMD : gulp webdriver_update 
 * To Update webdriver 
 **/
gulp.task('webdriver_update', webdriver_update);

/** CMD : gulp webdriver_standalone 
 * To start webdriver_standalone
 **/
gulp.task('webdriver_standalone', webdriver_standalone);

/** CMD : gulp e2e 
 * Run Protractor end 2 end test
 * */
gulp.task('e2e', ['webdriver_update'], function() {
  gulp.src("./e2etest/spec/*.js")
    .pipe(protractor({
      configFile: "./e2etest/Conf.js",
      reportDir:"../../report/Clientside-Report/End2endtest/",
      args: ['--baseUrl', 'http://localhost:8000/wwwroot/']
    }))    
  .on('error', function(e) { throw e })
});

/** CMD : gulp task
 *  To execute npm start command
 **/
gulp.task('task', function (cb) {
  exec('npm start', function (err, stdout, stderr) {
    console.log(stdout);
    console.log(stderr);
    cb(err);
  });
});

/** CMD : gulp e2etest 
 * Start node.js server
 * Run Protractor end 2 end test
 **/
gulp.task("e2etest",["webserver","e2e"]);

/** CMD : gulp dnx-web
 *  Run Server-side Integration test
 * */
gulp.task('dnx-web', dnx('web ASPNET_ENV=Development', weboptions));

/** CMD : gulp dnx-run
 *  Run Server-side Integration test
 * */
gulp.task('dnx-run', dnx('test', itoptions));

/** CMD : gulp dnx-unit-run 
 * Run Server-side Unittest
 **/
gulp.task('dnx-unit-run', dnx('test', utoptions));

/** CMD : gulp min
 *  To Minifying js and css
 **/
gulp.task("min", ["min:js", "min:css"]);

/** CMD : gulp minangular 
 * To Minifying app.js
 **/
gulp.task("minangular", ["min:apjs"]);

/** CMD : gulp min
 *  To Minifying js,css and app.js 
 * */
gulp.task("default", ["min", "minangular"]);

/** CMD : gulp run-client-test
 *  Run Client-side Unittest,
 *      Client-side Integration test,
 *      Protractor end 2 end test 
 * */
 gulp.task('run-client-test',["unittest","mochatest","e2etest"]);
 
 /** CMD : gulp run-server-test
 *  Run Server-side unittest,
 *      Server-side Integration test 
 * */
 gulp.task('run-server-test',["dnx-unit-run","dnx-run"]);
 
/** CMD : gulp run-test
 *  Run Client-side Unittest,
 *      Client-side Integration test,
 *      Server-side unittest,
 *      Server-side Integration test,
 *      Protractor end 2 end test 
 * */
gulp.task('run-test',["unittest","mochatest","dnx-unit-run","dnx-run","e2etest"]);

/** CMD : gulp clean
 *  To clean js,css and app.js 
 * */
gulp.task("clean", ["clean:js", "clean:css"]);