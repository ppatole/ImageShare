<?php 

include("DbConnect.php");

function getCategories(){

    

    // array for json response

    $response = array();

    $response["videodata"] = array();

   

    // Mysql select query
mysql_query("SET NAMES UTF8");
    $result = mysql_query("SELECT * FROM videolink");

     

    while($row = mysql_fetch_array($result)){

        // temporary array to create single category

    

	    $tmp = array();

        $tmp["vid"] = $row["vid"];

        $tmp["cid"] = $row["cid"];

         $tmp["vname"] = $row["vname"];

		   $tmp["vlink"] = $row["vlink"];
 
	    $tmp["status"] = $row["status"];

        // push category to final json array

        array_push($response["videodata"], $tmp);

    }

     

    // keeping response header to json

    header('Content-Type: application/json');

     

    // echoing json result

    echo json_encode($response);

}

 

getCategories();

?>