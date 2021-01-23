<?php
include_once('header.php');
?>

<body class="bg-info">
<div class="topnav">
    <a href="index.php">Home</a>
    <a href="data.php">Data</a>
    <a class="active" href="about.php">About The Data</a>
</div>
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1>About The Data</h1>
            <p>This data was taken from a dataset provided by Plymouth City Council.
                It shows the different types of crimes that occur and how many incidents happen each year from 2003-2015.
                The data also gives a total incident count for each year.</p>
            <p>The dataset is publicly available to view and download <a href="https://plymouth.thedata.place/dataset/crime">here</a>.
                You will also be able to find more information about the data, such as the date it was most recently updated.
            </p>
        </div>
    </div>
</div>

<?php
include_once('footer.php');
?>
