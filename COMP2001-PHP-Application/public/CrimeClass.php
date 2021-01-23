<?php
class CrimeClass
{
    public $Crime;
    public $Year;
    public $Amount;
    public function __construct($inArr)
    {
        $this->Crime = $inArr[0];
        $this->Year =$inArr[1];
        $this->Amount = $inArr[2];
    }
}
?>
