<?php
require 'php/conn.php';
$mobile = 8685873433;
$mail = 'Uditdhiman91@gmail.com';
$pass ='Admin@123';
// Function to hash a password using md5
function hashPassword($password) {
    $hashed_password = md5($password);
    return $hashed_password;
}

$hashed_password = hashPassword($pass);
$sql =" INSERT INTO `admin`(`mobile no`, `Email`, `Pass`) VALUES ('{$mobile}','{$mail}','{$hashed_password}')";
$result = mysqli_query($conn, $sql);
if($result){
    echo "successfull";
}
?>