/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    // load Grunt plugins from NPM
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');

    // configure plugins
    grunt.initConfig({
        uglify: {
            my_target: {
                files: { 'wwwroot/app.js': ['Scripts/app.js', 'Scripts/Service/*.js','Scripts/Controller/*.js'] }
            }
        },

        watch: {
            scripts: {
                files: ['Scripts/**/*.js'],
                tasks: ['uglify']
            }
        },
        
      protractor: {
      options: {
        keepAlive: true,
        configFile: "./e2etest/Conf.js"
      },
      singlerun: {},
      auto: {
        keepAlive: true,
        options: {
          args: {
            seleniumPort: 4444
          }
        }
      }
    },
    
    // Test settings
    karma: {
      unit: {
        configFile: 'karma.conf.js'
        
      }
    }
    });
    
    

  

    // define tasks
    grunt.registerTask('default', ['uglify', 'watch','test']);
    
   grunt.registerTask('test:e2e', ['protractor:singlerun']);
  
};