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
    var instructors, load, mapData, postInstructor, postName;
    postName = ko.observable();
    instructors = ko.observableArray([]);
    load = function() {
      return $.getJSON("/api/Instructors", function(data) {
        return mapData(data);
      });
    };
    mapData = function(data) {
      var mappedItems;
      mappedItems = $.map(data, function(item) {
        return Instructor(item);
      });
      return instructors(mappedItems);
    };
    postInstructor = function(postName) {
      var postJson;
      postJson = $.parseJSON('{"Id":0, "Name": "' + this.postName() + '"  }');
      return $.post('/api/Instructors', postJson, function(data) {
        console.log('done with post:     ' + data);
        return instructors.push(Instructor(data));
      });
    };
    return {
      postInstructor: postInstructor,
      postName: postName,
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
