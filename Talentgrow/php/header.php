
<?php
session_start();
if (!isset($_SESSION['pass']) || $_SESSION['Admin_login'] != true) {
    echo '<script>
           window.location.href="Admin.PHP"
           </script>';
    session_regenerate_id();
} else {
    
}
?>
<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <link rel="stylesheet" href="https://cdn.datatables.net/2.1.7/css/dataTables.dataTables.css" />
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    <script src="https://cdn.datatables.net/2.1.7/js/dataTables.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link rel="stylesheet" href="~/Assets/css/Adminheadercss.css" />
</head>

<body>
     <style>
        
/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
}

/* Firefox */
input[type=number] {
    -moz-appearance: textfield;
}

/* width */


::-webkit-scrollbar {
    width: 4px;
    height: 4px;
}

/* Track */
::-webkit-scrollbar-track {
    box-shadow: inset 0 0 5px grey;
    border-radius: 5px;
}

/* Handle */
::-webkit-scrollbar-thumb {
    background: rgb(78, 159, 197);
    border-radius: 10px;
}

    /* Handle on hover */
    ::-webkit-scrollbar-thumb:hover {
        background: #b30000;
    }

.top_menu {
    display: flex;
    justify-content: space-between;
}

.top_menu_list > ul > li {
    display: inline-block;
}

.dash_layout {
    position: relative;
}

    .dash_layout > div {
        display: inline-block;
    }

.sidemenu {
    position: fixed;
    top: 0px;
    width: 17%;
    height: 650px;
    border-radius: 5px;
}

    .sidemenu > div {
        height: 100%;
        overflow-y: scroll;
    }

.containt_div {
    position: fixed;
    /* background-color: red; */
    top: 8px;
    right: 5px;
    width: 81%;
    height: 100%;
    border: 2px solid rgba(220, 220, 220, 0.623);
    border-radius: 5px;
}

    .containt_div > div {
        width: 100%;
        height: 100%;
    }

        .containt_div > div > div {
            width: 100%;
            height: 100%;
            overflow: scroll;
            border-bottom: 2px solid rgb(37, 34, 34);
        }

.sidemenu {
    display: flex;
    justify-content: left;
}

    .sidemenu > div {
        margin-top: 30px;
        background-color: rgb(141, 71, 82);
        border-radius: 10px;
    }

        .sidemenu > div > ul {
            margin-top: 20px;
            margin-left: -20px;
        }

            .sidemenu > div > ul > li {
                list-style: none;
                text-align: left;
                padding: 5px 7px;
                margin: -10px;
                width: 95%;
                font-weight: bold;
                color: white;
            }

            .sidemenu > div > ul > li {
                color: white;
                cursor: pointer;
                white-space: nowrap;
            }

                .sidemenu > div > ul > li > a {
                    padding: 5px 7px;
                    text-decoration: none;
                    width: 100%;
                    display: flex;
                    justify-content: space-between;
                    border-radius: 5px;
                    font-weight: bold;
                    color: white;
                    white-space: nowrap;
                    overflow:hidden;
                }

                    .sidemenu > div > ul > li > a:hover {
                        background-color: rgba(81, 190, 71, 0.849);
                    }

                .sidemenu > div > ul > li > span {
                    padding: 5px 7px;
                    text-decoration: none;
                    width: 100%;
                    display: flex;
                    justify-content: space-between;
                    border-radius: 5px;
                }
           

            .sidemenu > div > ul > li > span:hover {
                background-color: rgba(253, 39, 11, 0.904);
            }

                .sidemenu > div > ul > li > ul {
                    display: none;
                }

                    .sidemenu > div > ul > li > ul > li {
                        list-style: none;
                        padding: 5px 8px;
                        border-radius: 5px;
                        margin-left: -40px;
                        margin-top: 5px;
                    }
                    .sidemenu > div > ul > li > ul > li:nth-child(1) {
                        padding-top:2px;
                    }

                        .sidemenu > div > ul > li > ul > li > a {
                            padding: 5px 7px;
                            display: inline-block;
                            width: 100%;
                            border-radius: 5px;
                            text-decoration: none;
                            color: white;
                            white-space: nowrap;
                            overflow: hidden;
                        }

                            .sidemenu > div > ul > li > ul > li > a:hover {
                                background-color: rgba(81, 190, 71, 0.849);
                            }

    </style>


    <div class="modal fade" id="deletemodel" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel">Delete</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" id="clbtn"></button>
            </div>
            <div class="modal-body">
                <form id="Deleteform">
                    <div class="form-group">
                        <input type="number" class="form-control w-100" name="id" id="del_id" required hidden />
                        <h5 id=""> Are you sure you want to Delete</h5>
                    </div>

                    <div class="modal-footer">

                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="submit" class="btn btn-danger">Delete</button>
                    </div>
                </form>

            </div>

        </div>
    </div>
</div>
    <div class="container-fluid pt-2">
        <div class="top_menu">
            <div class="logo">
                <img src="~/Assets/img/images/Capture.PNG" alt="" class="mx-2" style="width: 50PX" />
            </div>
            
            <div class="top_menu_list">
                <!-- <ul class="my-2 mx-3 ">
                    <li class="me-3">
                        <a href="
                      "><i class="bi bi-gear text-dark"></i></a>
                    </li>
                    <li class="me-3">
                        <a href="
                      "><i class="bi bi-bell fs-5 text-dark"></i></a>
                    </li>
                    <li class="me-3">
                        <div class="btn-group">
                            <button type="button" class="btn btn-outline-secondary">
                                <img src="" alt="" width="20px" style="border-radius: 25PX;">
                                Udit

                            </button>
                            <button type="button"
                                    class="btn btn-outline-secondary dropdown-toggle dropdown-toggle-split"
                                    data-bs-toggle="dropdown" aria-expanded="false">
                                <span class="visually-hidden">Toggle Dropdown</span>
                            </button>
                            <ul class="dropdown-menu shadow">
                                <li><a class="dropdown-item" href="#">Action</a></li>
                                <li><a class="dropdown-item" href="#">Another action</a></li>
                                <li><a class="dropdown-item" href="#">Something else here</a></li>
                                <li>
                                    <hr class="dropdown-divider">
                                </li>
                                <li><a class="dropdown-item" href="#">Separated link</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class="me-3 d-none d-md-block d-lg-none ">
                        <i class="bi bi-list  fs-4"></i>
                    </li>


                </ul> -->
            </div>
        </div>
        <div class="dash_layout">
            <div class="sidemenu">
                <div class="mt-2">
                    <div class="mt-2 text-center">

                        <img src="Assets/Imgs/Capture-removebg-preview (1).png" alt="" class="mx-2" style="width: 150PX" />
                    </div>
                    <hr style="color: white;">
                    <ul class="mt-4">
                        <li class="drop_btn">
                            <a href="Dashboard.php"><span><i class="bi bi-calendar2-plus-fill px-2"></i>Dashbaoard</span><span></span></a>
                        </li>
                        <li class="drop_btn">
                            <a href="Requests.php"><span><i class="bi bi-calendar2-plus-fill px-2"></i>Requests</span><span></span></a>
                        </li>
                        <li class="drop_btn">
                            <a href="checked.php"><span><i class="bi bi-calendar2-plus-fill px-2"></i>Viewed</span><span></span></a>
                        </li>   
                    </ul>
                </div>

            </div>
            <div class="containt_div">
                <div class="main">
                    <div class="pages">
                        <div class="px-3">