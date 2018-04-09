// Write your JavaScript code.
console.log("YOOOOO!");
$("#check").on("click", () => {
    checkApi();
});

function checkApi()
{
    $.get("/pokemon/1", (res) => {
        console.log("response", res);
    });
}