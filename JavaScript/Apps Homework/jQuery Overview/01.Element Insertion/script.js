(function($){
    $(document).ready(function(){
        $("#element").before().prepend("<p>Before</p>");
        $("#element").after().append("<p>After</p>");

    });
})(jQuery);