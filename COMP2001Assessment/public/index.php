<?php
include_once('header.php');
?>

<body class="bg-info">
<div class="topnav">
    <a class="active" href="index.php">Home</a>
    <a href="data.php">Data</a>
    <a href="about.php">About the Data</a>
</div>
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1>Welcome</h1>
            <p>For those interested in keeping an eye on the crime rates in Plymouth,
                this website displays data statistics about the amount and type of crime committed in Plymouth.
                To view this information simply click on the "Data" link at the top of the page.</p>
            <p>More information about the dataset can be found on the "About the Data" page.</p>
            <p>A link to the original dataset can be found <a href="https://plymouth.thedata.place/dataset/crime">here</a>.</p>
        </div>
        <div class="card mt-3 px-2 py-2">
            <p>The data displayed on the "Data" page is in a human readable format.
                This application also provides semantic markup for machine-to-machine consumption.
                The machine readable linked data markup can be found <a href="MRcrime.php">here</a>.
                This will provide you with the JSON-LD markup for all the information displayed on the Data page.</p>
        </div>
    </div>
</div>

<?php
include_once('footer.php');
?>
