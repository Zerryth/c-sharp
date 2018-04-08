$(document).ready(function() {
    let happiness = 20;
    let fullness = 20;
    let energy = 50;
    let meals = 3;
    let message = "";
    let continueGame = true;
    
    updateStatus();

    $("#feedBtn").on("click", () => {
        feed();
    });
    $("#playBtn").on("click", () => {
        play();
    });
    $("#workBtn").on("click", () => {
        work();
    });
    $("#sleepBtn").on("click", () => {
        sleep();
    });
    $("#restart").on("click", () => { 
        restart();
    })

    function checkLoss()
    {
        let loss = false;
        if (fullness <= 0 || happiness <= 0)
        {
            continueGame = false;
            loss = true;
            message = "Your Dojodachi has passed away...";
            $("#message").addClass("red");
            $("#bunny").fadeOut();
            $("#rip").delay(400).fadeIn();
        }
        return loss;
    }

     function checkWin()
    {
        let win = false;
        if ((energy >= 30) && (fullness >= 30) && (happiness >= 30))
        {
            continueGame = false;
            win = true;
            message = "Congratulations! You won!";
            $("#message").addClass("orange");
            $("#bunny").fadeOut();
            $("#happy").delay(400).fadeIn();
        }
        return win;
    }

    function feed()
    {
        $.get("/feed/"+ fullness +"/" + meals , (res) => {
            fullness = res.fullness;
            meals = res.meals;
            message = res.message;
            updateStatus();
        });
    }
    function getStatus()
    {
        $.get("/status/" + happiness + "/" + fullness + "/" + energy + "/" + meals, (res) => {
            console.log(res);
        });
    }

    function play()
    {
        $.get("play/" + happiness + "/" + energy, (res) => {
            happiness = res.happiness;
            energy = res.energy;
            message = res.message;
            updateStatus();
        });
    }

    function restart(){
        location.reload(true);
    }

    function showRestartBtn()
    {
        if (!continueGame)
        {
            $(".action_buttons").slideUp();
            $("#restart").slideDown();
        }
    }

    function sleep()
    {
        $.get("sleep/" + energy + "/" + fullness + "/" + happiness, (res) => {
            energy = res.energy;
            fullness = res.fullness;
            happiness = res.happiness;
            updateStatus();
        });
    }

    function updateStatus()
    {
        checkLoss();
        checkWin();
        $("#happiness").text(happiness);
        $("#fullness").text(fullness);
        $("#energy").text(energy);
        $("#meals").text(meals);
        $("#message").text(message);
        getStatus();
        showRestartBtn();
    }

    function work()
    {
        $.get("work/" + meals + "/" + energy, (res) => {
            meals = res.meals;
            energy = res.energy;
            message = res.message;
            updateStatus();
        });
    }
});