<?php
require_once("CrimeModel.php");

class MRcrimeView extends CrimeModel
{
    public function display()
    {
        $data = $this->loadData();
        $array = array();
        foreach ($data as $row):
            array_push($array, (object)array(
                "@type" => "Crime & Year",
                "CrimeCount" => array(
                    "@type" => "CrimeCount",
                    "Crime" => $row->Crime,
                    "Year" => $row->Year,
                    "Amount" => $row->Amount,
                )));
        endforeach;
        return $array;
    }
}