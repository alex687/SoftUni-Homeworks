(function($){
    $(document).ready(function(){
        $("#painter").click(function(){
            var classNameToPaint = $('#className').val();
            var color = $("#colorPick").val();

            try{
                 $("." + classNameToPaint).css('background', color);
            }catch (err){
                if(err instanceof Error){
                    alert("Invalid class name or color.");
                }
                else {
                    throw err;
                }
            }
        });
    });
})(jQuery);