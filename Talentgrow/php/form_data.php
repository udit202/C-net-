<?php
// Database connection (adjust the values as needed)
require 'conn.php';

// Retrieve form data
$name = $_POST['name'];
$email = $_POST['email'];
$mobile = $_POST['mobile'];
$class = $_POST['class'];
$location = $_POST['location'];
$learn = $_POST['domains'];

// Input validation: Check for empty values
if (empty($name) || empty($class) || empty($mobile) || empty($email) || empty($location) || empty($learn)) {
    echo '2'; // Missing fields
    exit;
}

// Escape user input to avoid SQL injection
$name = mysqli_real_escape_string($conn, $name);
$email = mysqli_real_escape_string($conn, $email);
$mobile = mysqli_real_escape_string($conn, $mobile);
$class = mysqli_real_escape_string($conn, $class);
$location = mysqli_real_escape_string($conn, $location);
$learn = mysqli_real_escape_string($conn, json_encode($learn)); // Encode domains as JSON

// Check if email or mobile already exists in the database
$sql = "SELECT * FROM `requests` WHERE `email` = '$email' OR `mobile` = '$mobile'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    echo '3'; // Email or mobile already exists
} else {
    // Insert new record into the database
    $sql = "INSERT INTO `requests` (`name`, `mobile`, `class`, `location`, `learn`, `viewed`, `Email`) 
            VALUES ('$name', '$mobile', '$class', '$location', '$learn', '0', '$email')";

    if (mysqli_query($conn, $sql)) {
        echo '1'; // Success
    } else {
        echo '0'; // Query failed
    }
    
}

// Close connection
mysqli_close($conn);
?>
