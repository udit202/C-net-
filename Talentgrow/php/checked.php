<?php
require 'conn.php';


$output = ''; // Initialize the output

$sql = "SELECT * FROM `requests` WHERE `viewed`='1'";
$result = mysqli_query($conn, $sql);

if ($result) {
    if (mysqli_num_rows($result) > 0) {
        $num = 1;

        while ($row = mysqli_fetch_assoc($result)) {
            $learn_array = json_decode($row['learn'], true);

            // Start generating table row
            $output .= "<tr>
                <td>{$num}</td>
                <td>{$row['name']}</td>
                <td>{$row['mobile']}</td>
                <td><div style='width:150px;height:60px; overflow-x:scroll;'>{$row['Email']}</div></td>
                <td>{$row['class']}</td>
                <td>{$row['location']}</td>
                <td>";

            // Loop through the learn array
            foreach ($learn_array as $data) {
                $output .= $data . "<br>";
            }

            // Continue generating the row with the operation icons
            $output .= "</td>
            <td>
                <div style='width:150px'>
                      <i class='bi bi-trash3 del_btn mx-2 ' style ='color:red; cursor:pointer;' data-bs-toggle='modal' data-bs-target='#deletemodel'    data-id='{$row['id']}' ></i>
                    <i class='bi bi-telegram m-2 share' data-name='{$row['name']}' style ='color:blue; cursor:pointer;'
                    data-name='{$row['name']}'   
                            data-mobile='{$row['mobile']}' 
                            data-email='{$row['Email']}' 
                            data-class='{$row['class']}' 
                            data-location='{$row['location']}' 
                            data-learn='{$row['learn']}'></i>
                </div>
            </td>
        </tr>";

            $num++;
        }
    } else {
        $output = "<tr><td colspan='8'>No records found.</td></tr>"; // No data case
    }
} else {
    $output = "<tr><td colspan='8'>Query failed: " . mysqli_error($conn) . "</td></tr>"; // Query error case
}

echo $output;
?>
