var MainViewModel = function () {
    var self = this;
    var drawerOpen = false;

    self.openDrawer = function () {
        $("#filters").animate({ left: 0 });
        $(".button").animate({ left: 240 });
        $('.button').text('<');
    };

    self.hideDrawer = function () {
        $("#filters").animate({ left: -240 });
        $(".button").animate({ left: 0 });
        $('.button').text('>');
    };

    self.toggleDrawer = function () {
        drawerOpen ? self.hideDrawer() : self.openDrawer();
        drawerOpen = !drawerOpen;
    };

    self.filterClicked = function () {
        // TODO
    };

    self.filters = ko.observableArray();

    var promise = App.rest.fetchAllFilters();
    promise.done(function (data) {
        self.filters(data);
    });

    self.top_filter = function (data, event) {
        App.sigma.combineInClusters(data);
    };
};

ko.applyBindings(new MainViewModel());
