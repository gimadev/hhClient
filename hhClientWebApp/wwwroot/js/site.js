

$.ajax({
    type: "get",
    dataType: "json",
    url: "home/list",
    success: function(data){
        if(data.found > 0){
            $('#itemTmpl').tmpl(data.items).appendTo('#list-content');
        }
    }
});
