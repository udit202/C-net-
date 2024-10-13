<?php include 'php/header.php';

?>
<style>
    select.dt-input {
        margin-right: 10px;
    }

    .containt_div {
        height: 98%;
    }

    .fetched_img {
        width: 100px;
    }
</style>

<div class="row mt-2">
    <div class="col-6">
        <h3 style="color: navy; font-family: Algerian;">Requests</h3>
    </div>
    <div class="col-6 text-end">
    <a href="php/Logout.php" class="btn btn-danger mt-2" >
            Logout
</a>
    </div>
</div>
<hr style="color:navy" />

<div id="Fetc_here">
    <table id="requestsTable" class="display">
        <thead>
            <tr>
                <th>NO:</th>
                <th>Name</th>
                <th>Mobile No</th>
                <th>Email</th>
                <th>Class</th>
                <th>College</th>
                <th>Interested In</th>
                <th>Operations</th>
            </tr>
        </thead>
        <tbody id="content">
            <!-- AJAX will populate this -->
        </tbody>
    </table>
</div>

  <!-- Button trigger modal -->

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
<script>
    function fetch_data() {
        $.ajax({
            url: 'php/fetch_requests.php', // Path to your PHP file
            type: 'GET', // HTTP request method
            success: function(response) {
                $('#content').html(response); // Insert the response (rows) inside tbody
            },
            error: function(xhr, status, error) {
                console.error('AJAX Error:', status, error);
            }
        });
    }

    
</script>

<?php require 'php/footer.php';?>
