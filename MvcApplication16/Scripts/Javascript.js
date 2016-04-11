

$(function () {
    $(".SmallPics").on('click',function(){
        var CurrentPic = $(this);
        var src = this.src;
        $('.BigPic').fadeOut(10, function () {
            CurrentPic.src = this.src;
             $(this).fadeIn(10)[0].src = src;
    });
    });
    $("#File2").hide()
    $("#File3").hide()
    $("#File4").hide()
    $("#File5").hide()


    console.log("#File1".val)

    
    //if ($("#File2").val != '') {
    //    $("#File3").show()
    //}
    //if ($("#File3").val != '') {
    //    $("#File4").show()
    //}
    //if ($("#File4").val != '') {
    //    $("#File5").show()
    //}
});


        
