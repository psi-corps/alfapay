// --------------- Imports ---------------------------------------------------------------------

var gulp = require('gulp');
var source = require('gulp-sourcemaps');
var concat = require('gulp-concat');
var html2js = require('gulp-html2js');
var babel = require('gulp-babel');
var less = require('gulp-less');
var sync = require('browser-sync').create();
var colors = require('colors')
var rmrf = require('rimraf');
var fs = require('fs');

// ---------------------------------------------------------------------------------------------



// ------------ Configuration ------------------------------------------------------------------

var config = {
   path: {
      src: {
         scripts: './src/scripts/**/*.js',
         styles: './src/styles/**/*.less',
         tmpl: './src/scripts/**/*.html',
         html: './src/html/**/*.html'
      },
      dest: {
         scripts: './scripts.js',
         styles: './styles.css',
         tmpl: './templates.js'
      }
   },
   watch: {
      timeout: {
         scripts: 2000,
         styles: 2000,
         html: 2000,
         tmpl: 2000
      }
   },
   sync: {
      files: './dev/**/*',
      server: {
      	baseDir: './www'
      },
      port: 4000,
      open: true,
      notify: true,
      reloadDelay: 2000
   }
};

// ---------------------------------------------------------------------------------------------



// ------------ DEV environment ----------------------------------------------------------------

gulp.task('dev:build:scripts', () =>
   gulp.src(config.path.src.tmpl)
      .pipe(source.init())
         .pipe(html2js(config.path.dest.tmpl), {adapter:'angular', name:'alfapay'})
         .pipe(gulp.src(config.path.src.scripts))
         .pipe(concat(config.path.dest.scripts))
         .pipe(babel())
         .pipe(source.write())
      .pipe(gulp.dest(config.sync.server.baseDir)));

gulp.task('dev:build:styles', () =>
	gulp.src(config.path.src.styles)
	   .pipe(source.init())
	      .pipe(concat(config.path.dest.styles))
	      .pipe(source.write())
	   .pipe(gulp.dest(config.sync.server.baseDir)));

gulp.task('dev:build:html', () => 
	gulp.src(config.path.src.html)
	   .pipe(gulp.dest(config.sync.server.baseDir)));


gulp.task('dev:serve', () => {
   console.log(colors.yellow(`Attempt to create web root: ${config.sync.server.baseDir}...`));

   if (fs.existsSync(config.sync.server.baseDir)) {
      console.log(colors.red(`Error. Path ${config.sync.server.baseDir} already exists`));
   } else {
      fs.mkdir(config.sync.server.baseDir);
      console.log(colors.green('Done.'));
      sync.init(config.sync, listen);	
   }
});

gulp.task('dev:clean', () => {
   console.log(colors.yellow(`Attemp to clean files in ${config.sync.server.baseDir}`));
   
   if (!fs.existsSync(config.sync.server.baseDir)) {
      console.log(colors.green('Nothing to clean.'));
   } else if (fs.statSync(config.sync.server.baseDir).isDirectory()) {
   	  rmrf.sync(config.sync.server.baseDir);
   	  console.log(colors.green('Done.'))
   } else {
   	  console.log(colors.red(`${config.sync.server.baseDir} is not directory.`));
   }
});

gulp.task('dev:run', ['dev:serve', 'dev:build:scripts', 'dev:build:styles'], () => {
   watch(config.path.src.scripts, 'dev:build:scripts', config.watch.timeout.scripts);
   watch(config.path.src.styles, 'dev:build:styles', config.watch.timeout.styles);
   watch(config.path.src.html, 'dev:build:html', config.watch.timeout.html);
   watch(config.path.src.tmpl, 'dev:build:tmpl', config.watch.timeout.tmpl);
});

// ---------------------------------------------------------------------------------------------



// ------------ Internal functions -------------------------------------------------------------

function watch(target, task, timeout) {
   var watch = gulp.watch(target, [task]);
   var tid = setTimeout(watch.end, timeout);

   watch.on('change', () => {
      clearTimeout(tid);
      tid = setTimeout(watch.end, timeout);
   });

   console.log(colors.green(`Watching for: ${target} with [${task}]. Timeout is ${timeout}.`));
};

function listen() {
   console.log(colors.green('+------------------------------------------------------+'));
   console.log(colors.green('| DEV environment is running, press any key to stop it |'));   
   console.log(colors.green('| Do not use ^C or ^Z instead of resources leak.       |'));
   console.log(colors.green('+------------------------------------------------------+'));
   process.stdin.setRawMode(true);
   process.stdin.resume();
   process.stdin.on('data', process.exit);
}

// ---------------------------------------------------------------------------------------------