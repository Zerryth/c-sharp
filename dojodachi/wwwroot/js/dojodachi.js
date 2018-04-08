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
        if (fullness <= 0 || happiness <= 0)
        {
            continueGame = false;
            message = "Your Dojodachi has passed away...";
            $("#message").addClass("red");
            $("#bunny").fadeOut();
            $("#rip").delay(400).fadeIn();
        }
        return continueGame;
    }

     function checkWin()
    {
        if ((energy >= 30) && (fullness >= 30) && (happiness >= 30))
        {
            continueGame = false;
            message = "Congratulations! You won!";
            $("#message").addClass("orange");
            $("#bunny").fadeOut();
            $("#happy").delay(400).fadeIn();
        }
        return continueGame;
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

    function showActionImg()
    {
        if (message.search(/fed/) != -1)
        {
            $("#carrot").slideDown().delay(300).slideUp();
        }
        else if (message.search(/played/) != -1)
        {
            $("#ball").slideDown().delay(300).slideUp();
        }
        else if (message.search(/worked/) != -1)
        {
            $("#briefcase").slideDown().delay(300).slideUp();
        }
        else if (message.search(/slept/) != -1)
        {
            $("#sleep").slideDown().delay(300).slideUp();
        }
    }

    function sleep()
    {
        $.get("sleep/" + energy + "/" + fullness + "/" + happiness, (res) => {
            energy = res.energy;
            fullness = res.fullness;
            happiness = res.happiness;
            message = res.message;
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
        showActionImg();
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