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
    var deleteId, deleteInstructor, instructors, load, mapData, postInstructor, postName, putId, putInstructor, putName;
    postName = ko.observable();
    putName = ko.observable();
    putId = ko.observable();
    deleteId = ko.observable();
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
    putInstructor = function(postName) {
      var json;
      json = $.parseJSON('{"Id":' + this.putId() + ', "Name": "' + this.putName() + '"  }');
      return $.ajax({
        type: 'PUT',
        url: '/api/Instructors',
        data: json
      }, function(data) {
        console.log('done');
        return load;
      });
    };
    deleteInstructor = function(id) {
      var json;
      json = $.parseJSON('{"Id":1 }');
      return $.ajax({
        type: 'DELETE',
        url: '/api/Instructors',
        data: json
      }, function(data) {
        return console.log('done');
      });
    };
    return {
      postInstructor: postInstructor,
      deleteInstructor: deleteInstructor,
      putInstructor: putInstructor,
      postName: postName,
      putName: putName,
      putId: putId,
      deleteId: deleteId,
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
