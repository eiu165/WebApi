Instructor = (data) ->
    Name = ko.observable(data.Name)
    Id = ko.observable(data.Id)
    Name:Name
    Id:Id 
viewModel =-> 
    postName = ko.observable()
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
    postInstructor:postInstructor
    postName:postName
    instructors:instructors     
    load:load        
$(->    
    console.log 'start'   
    vm = new viewModel()
    vm.load()
    ko.applyBindings(vm)
    this
)