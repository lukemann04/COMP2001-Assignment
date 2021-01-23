<?php
require_once("MRcrimeView.php");

$crimes = new MRcrimeView();
$json = (object)array("Crimes" =>$crimes->display());
header('Content-type: application/json');
echo '{"@context": { "Crimes" : "http://schema.org", "Crime" : "http://web.socem.plymouth.ac.uk" },';
?>
<?php
echo json_encode($json, JSON_PRETTY_PRINT);
?>
<?php
echo '}'
?>