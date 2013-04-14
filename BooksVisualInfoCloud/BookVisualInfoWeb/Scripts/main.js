var MainViewModel = function() {
    var self = this;
    var drawerOpen = false;
    
    self.openDrawer = function() {
        $("#filters").animate({left:0});
        $(".button").animate({left:240});
        $('.button').text('<');
    };
    
    self.hideDrawer = function() {
        $("#filters").animate({left:-240});
        $(".button").animate({left:0});
        $('.button').text('>');
    };
    
    self.toggleDrawer = function() {
        drawerOpen ? self.hideDrawer() : self.openDrawer();
        drawerOpen = !drawerOpen;
    };
    
    self.filterClicked = function() {
        // TODO
    };
};

ko.applyBindings(new MainViewModel());
