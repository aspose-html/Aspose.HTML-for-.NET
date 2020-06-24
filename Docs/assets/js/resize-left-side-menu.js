const GUTTER_SIZE = 1;
const MIN_LEFTBAR_SIZE = 12;
const MAX_LEFTBAR_SIZE = 32;

var leftSideId = '#left-side-bar-menu';
var rightSideId = '#right-side';
var gutterId = '#sidebar-resizer';

function clearStyles(objectId, classToRemove) {
  $(objectId).removeAttr("style");
  $(objectId).removeClass(classToRemove);
}

function setStyles(objectId, classToAdd) {
  if(!$(objectId).hasClass(classToAdd)) {
    $(objectId).addClass(classToAdd);
  }
}

function calcLeftFotGutter() {
  var leftSideWidthPercent = $(leftSideId).width() / $(window).width() * 100;
  
  return GUTTER_SIZE + $(leftSideId).width() + 15 + 'px';
}

function getLefSideWidth() {
  return $(leftSideId).width() / $(window).width() * 100;
}

function calcGutterPosition() {
  if(getLefSideWidth() < MAX_LEFTBAR_SIZE && getLefSideWidth() > MIN_LEFTBAR_SIZE) {      
    $(gutterId).css('left', calcLeftFotGutter());
  }
  if(getLefSideWidth() > MAX_LEFTBAR_SIZE) {
    console.log("MAAAAX condition.  $(gutterId).css('left') = " +  $(gutterId).css('left'));
    $(gutterId).css('left', '32%');
  }
  if(getLefSideWidth() < MIN_LEFTBAR_SIZE) {
      $(gutterId).css('left', `calc(${getLefSideWidth()} + 1px)`);
    console.log("MIN condition.  $(gutterId).css('left') = " +  $(gutterId).css('left'));
  }
  console.log("$(gutterId).css('left') = " +  $(gutterId).css('left'));
}

function setGutterStyles(gutterElementId) {
  $(gutterElementId).show();
  $(gutterElementId).css('padding', `0.01rem`);
  $(gutterElementId).css('left', calcLeftFotGutter());
  $(gutterElementId).css('height', $(leftSideId).css('height'));
  $(gutterElementId).css('cursor', 'ew-resize');
}

function removeStylesDependingOnWindowWidth() {
  if ($( window ).width() < 768 ) {
    $(gutterId).hide();
    clearStyles(leftSideId, "leftSideBarSize");
    clearStyles(rightSideId, "rightSideContent");
    console.log("ke = " + $( window ).width() );
  } else {
    setGutterStyles(gutterId);

    setStyles(leftSideId, "leftSideBarSize");
    setStyles(rightSideId, "rightSideContent");
    
    split();
  }
}

var split = function () {
  Split([leftSideId, rightSideId], {
  sizes: [17, 83],
  elementStyle: (dimension, size, gutterSize) => ({

      'flex': `0 0 calc(${size}% - ${GUTTER_SIZE/2}px)`,
  }),
  gutterStyle: (dimension, gutterSize) => ({
    'left': calcLeftFotGutter()
  }),
  onDrag: function(dimension, size, gutterSize) {
    calcGutterPosition();
  }, 
  onDragEnd: function(size, gutterSize) {
    calcGutterPosition();
  },
    gutter: (index, direction) => {
      const gutter = document.getElementById('sidebar-resizer');
      gutter.className = `gutter gutter-${direction}`
      return gutter
  }
});
}

split();
removeStylesDependingOnWindowWidth();

$( window ).resize(function() {
  removeStylesDependingOnWindowWidth();
});
