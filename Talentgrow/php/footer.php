</div>
</div>
</div>
</div>
</div>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"
    crossorigin="anonymous"></script>
    <script>
    $(document).ready(function() {
        // Initialize DataTables
        $('#requestsTable').DataTable();

        // Fetch data once the page is ready
        fetch_data();

        // Set delete ID in modal when delete button is clicked
        $(document).on('click', '.del_btn', function () {
            $('#del_id').val($(this).attr('data-id'));
        });

        // Handle the viewed button click
        $(document).on('click', '.viewed', function () {
            let data_id = $(this).attr('data-id');
            $.ajax({
                url: 'php/view.php', // The URL to send the request to
                type: 'POST', // The type of request
                data: { id: data_id }, // Send the ID as data (corrected syntax)
                success: function (response) {
                    if (response == 1) {
                        fetch_data(); // Refresh the data
                        swal("Good job!", "Successfully Viewed!", "success");
                    } else if (response == 0) {
                        swal("Error", "Error in the data view", "error");
                    } else {
                        swal("Error", "Try again", "error");
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error Status: " + status);
                    console.error("Error Thrown: " + error);
                    console.error("Response Text: " + xhr.responseText);
                    alert("An error occurred: " + xhr.status + " " + error + ". Please try again.");
                }
            });
        });
        $(document).on('click', '.share', function (e) {
    e.preventDefault();

    // Retrieve data attributes from the clicked element
    let name = $(this).attr('data-name');
    let mobile = $(this).attr('data-mobile');
    let email = $(this).attr('data-email');
    let studentClass = $(this).attr('data-class'); // Changed 'class' to 'studentClass' to avoid conflicts with JS keyword
    let learn = $(this).attr('data-learn');
    let location = $(this).attr('data-location');

    // Check if the browser supports the Web Share API
    if (navigator.share) {
        // Construct a message with all the details
        let shareMessage = `
            Name: ${name}
            Mobile: ${mobile}
            Email: ${email}
            Class: ${studentClass}
            Learn: ${learn}
            Location: ${location}
        `;

        // Use the navigator.share API to share data
        navigator.share({
            title: 'TalentGro',
            text: shareMessage, // Include all the data in the shared message
        }).then(() => {
            console.log('Thanks for sharing');
        }).catch((err) => {
            console.log('Error using share API:', err);
        });
    } else {
        alert("Browser doesn't support the Web Share API");
    }
});


        // Handle delete form submission via AJAX
        $("#Deleteform").submit(function (event) {
            event.preventDefault(); // Prevent default form submission

            var formData = new FormData(this); // Use FormData for form submission
            $.ajax({
                url: 'php/del.php', // The URL to send the request to
                type: 'POST', // The type of request
                data: formData, // The form data
                contentType: false, // Prevent jQuery from overriding the Content-Type
                processData: false, // Prevent jQuery from processing the data
                success: function (response) {
                    if (response == 1) {
                        document.getElementById("clbtn").click(); // Trigger close button
                        $("#Deleteform")[0].reset(); // Reset the form
                        fetch_data(); // Refresh the data
                        swal("Good job!", "Successfully Deleted!", "success");
                    } else if (response == 0) {
                        swal("Error", "Error in the data Deletion", "error");
                    } else {
                        swal("Error", "Try again", "error");
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error Status: " + status);
                    console.error("Error Thrown: " + error);
                    console.error("Response Text: " + xhr.responseText);
                    alert("An error occurred: " + xhr.status + " " + error + ". Please try again.");
                }
            });
        });
    });
</script>



</body>

</html>