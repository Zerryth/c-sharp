$(document).ready(function() {

    $(".delete").on("click", function() {
        deleteNote($(this).siblings("input").val()); // note id in hidden input's val
    });

    $(".editable").on("click", () => {}).blur(function(){
        let noteId = $(this).parent().siblings("input").val();
        let text = $(this).text(); 
        let classes = $(this).attr("class");
        editNote(noteId, text, classes);
    });

    function deleteNote(id)
    {
        $.ajax({
            url: "/notes/" + id,
            type: "DELETE",
            success: (res) => { }
        });
    }
    
    function editNote(noteId, text, classes){
        $.ajax({
            url: "/notes/" + noteId + "/" + text + "/" + classes,
            type: "PUT",
            success: (res) => { }
        })
    }
});