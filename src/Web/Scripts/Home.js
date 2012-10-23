(function() {
  var Instructor, viewModel;

  Instructor = function(data) {
    var Id, Name;
    Name = ko.observable(data.Name);
    Id = ko.observable(data.Id);
    return {
      Name: Name,
      Id: Id
    };
  };

  viewModel = function() {
    var instructors, load, mapData;
    instructors = ko.observableArray([]);
    load = function() {
      console.log('load');
      return $.getJSON("/api/Instructors", function(data) {
        return mapData(data);
      });
    };
    mapData = function(data) {
      var mappedItems;
      console.log('in mapData ' + data);
      mappedItems = $.map(data, function(item) {
        return Instructor(item);
      });
      console.log('after mapitems');
      return instructors(mappedItems);
    };
    return {
      instructors: instructors,
      load: load
    };
  };

  $(function() {
    var vm;
    console.log('start');
    vm = new viewModel();
    vm.load();
    ko.applyBindings(vm);
    return this;
  });

}).call(this);
