<?php
require 'conn.php';
$sql = "UPDATE `requests` SET `viewed`='1' WHERE `id` = '{$_POST['id']}'";
$result = mysqli_query($conn, $sql);
$res;
if($result){
    $res=  '1';
}
else{
    $res= '0';
}
echo $res;
?>