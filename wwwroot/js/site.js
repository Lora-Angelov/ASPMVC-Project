// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<script>
    window.onload = function() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        console.log("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
        $.get("/Weather/Index", { latitude: position.coords.latitude, longitude: position.coords.longitude })
            .done(function (data) {


                public class Coord {
                    public double lat { get; set; }
        public double lon { get; set; }
    }

            });
}
</script>


