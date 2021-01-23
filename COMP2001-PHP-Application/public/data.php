<?php
include_once('header.php');
?>

<body class="bg-info">
<div class="topnav">
    <a href="index.php">Home</a>
    <a class="active"  href="data.php">Data</a>
    <a href="about.php">About The Data</a>
</div>
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1>Simple Dataset Display.</h1>
            <p>This table shows the types and amounts of each offence that occurs in Plymouth 2003-2015.</p>
            <?php
            $array = array();
            if (($handle = fopen('https://plymouth.thedata.place/dataset/85ccae9b-7437-4f4f-9442-dc65453c9f8c/resource/26904f63-e13a-450c-85c7-954b66229871/download/summary-of-all-offences-2003-2015.csv', 'r')) !== FALSE) {
                while (($data = fgetcsv($handle, 1000, ",")) !== FALSE) {
                    array_push($array, $data);
                }
                fclose($handle);
            }
            ?>
            <?php if (count($array) > 0): ?>
                <table class="table table-striped table-bordered">
                    <tbody>
                    <?php foreach ($array as $row): array_map('htmlentities', $row); ?>
                        <tr>
                            <th><?php echo implode('</th><td>', $row); ?></th>
                        </tr>
                    <?php endforeach; ?>
                    </tbody>
                </table>
            <?php endif; ?>
        </div>
    </div>
    <div class="row">
        <div class="card mt-3 px-2 py-2"></div>
    </div>
</div>

<?php
include_once('footer.php');
?>
