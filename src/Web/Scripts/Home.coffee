Instructor = (data) ->
    Name = ko.observable(data.Name)
    Id = ko.observable(data.Id)
    Name:Name
    Id:Id 
viewModel =-> 
    postName = ko.observable()
    putName = ko.observable()
    putId = ko.observable()
    deleteId = ko.observable()
    instructors = ko.observableArray([])      
    load = -> 
        $.getJSON("/api/Instructors",(data )->mapData(data )) 
    mapData = (data) -> 
        mappedItems = $.map( data , (item)-> Instructor(item) ) 
        instructors(mappedItems)  
    postInstructor = (postName) -> 
        postJson = $.parseJSON '{"Id":0, "Name": "' + this.postName() + '"  }' 
        $.post '/api/Instructors', 
            postJson, 
            (data) -> 
                console.log 'done with post:     ' +  data  
                instructors.push Instructor(data)  
    putInstructor = (postName) -> 
        json = $.parseJSON '{"Id":' + this.putId() + ', "Name": "' + this.putName() + '"  }' 
        $.ajax 
            type:'PUT'
            , url: '/api/Instructors'
            , data: json 
            , (data) -> 
                console.log 'done' 
    deleteInstructor = (id) -> 
        $.ajax 
            type:'DELETE'
            , url: '/api/Instructors/' + this.deleteId()
            , success: (data) -> 
                console.log 'done'
                load
    postInstructor:postInstructor
    deleteInstructor:deleteInstructor
    putInstructor:putInstructor 
    postName:postName
    putName:putName
    putId:putId 
    deleteId:deleteId
    instructors:instructors     
    load:load        
$(->
    console.log 'start'   
    vm = new viewModel()
    vm.load()
    ko.applyBindings(vm)
    this
)