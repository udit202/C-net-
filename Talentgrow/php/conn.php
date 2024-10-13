<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "talent_gro";

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);

// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}

// function verify_admin($url) {
// if (!isset($_SESSION['pass']) || $_SESSION['Admin_login'] != true) {
    
//     echo '<script>
//            window.location.href="Admin.PHP"
//            </script>';
//     session_regenerate_id();
// } else {
//     echo '<script>
//            window.location.href="
//            '.$url.'"
//            </script>';
// }
// }
?>