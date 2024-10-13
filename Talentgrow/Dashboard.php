<?php 

include 'php/header.php';

?>
<div class="row mt-2">
    <div class="col-6">
        <h3 style="color: navy; font-family: Algerian;">Dashboard</h3>
    </div>
    <div class="col-6 text-end">
        <a href="php/Logout.php" class="btn btn-danger mt-2" >
            Logout
</a>
    </div>
</div>
<hr style="color:navy" />
<div class="row">
    <div class="col-md-3">
        <div class="m-2  ">
            <div class="shadow p-3 rsounded">
            <h2>
            <?php
            require 'php/conn.php';            
            $sql = "SELECT * FROM `requests` WHERE `viewed`='0'";
            $result = mysqli_query($conn, $sql);
            if($result){
                $count = mysqli_num_rows($result);
                echo $count;
            }
            ?>
            </h2>
            <h4><i class="bi bi-bell-fill me-2 " style="color: blue;" ></i>Requests</h4>
            </div>
        </div>
    </div>
</div>
<?php require 'php/footer.php';?>