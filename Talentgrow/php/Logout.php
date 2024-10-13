<?php
session_start();
session_destroy();
echo '<script>
window.location.href="../Admin.PHP"
</script>';
// header('location : Login_page.Php');
?>