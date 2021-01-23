<?php
require_once("CrimeClass.php");
class CrimeModel
{
    protected function loadData()
    {
        $array = array();

        $data = file_get_contents('https://plymouth.thedata.place/dataset/85ccae9b-7437-4f4f-9442-dc65453c9f8c/resource/26904f63-e13a-450c-85c7-954b66229871/download/summary-of-all-offences-2003-2015.csv');
        $row = preg_split('/\n/', $data);
        $years = preg_split('/,/', $row[0]);

        $temp = array();
        for($i=0; $i < 19; $i++)
        {
            $tempv = preg_split('/,/', $row[$i+1]);
            for($j=0; $j < 13; $j++)
            {
                array_push($temp, $tempv[0]);
                array_push($temp, $years[$j + 1]);
                array_push($temp, $tempv[$j + 1]);
                array_push($array, new CrimeClass($temp));
                unset($temp);
                $temp = array();
            }
            unset($tempv);
        }
        return $array;
    }
}
