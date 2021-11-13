<?php
 
    const ID = 'id';
    const DESCRIPCION = 'descripcion';
 
    function get_response($connection, $json)
    {
 
		switch($json->request)
		{
 
			case 0:
 
				// CASE 0 CREAR CUENTA
				$query = "SELECT * FROM usuarios WHERE nombre = '$json->nombre'";
			    $result = mysqli_query($connection, $query);
			    if($result && mysqli_num_rows($result) > 0)
				{
                    return 'YA_EXISTE';
				}
				else
				{
				    $query = "INSERT INTO usuarios(nombre, pass, record) VALUES('$json->nombre','$json->pass', 0)";
					mysqli_query($connection, $query);
 
					return 'REGISTRADO';
				}
 
 
				break;
 
 
			case 1:
			    // CASE 1 COMPROBAR LOGIN
				$query = "SELECT * FROM usuarios WHERE nombre = '$json->nombre' AND pass = '$json->pass'";
			    $result = mysqli_query($connection, $query);
			    if($result && mysqli_num_rows($result) > 0)
				{
 
                    $info = array();
                    while($row = mysqli_fetch_assoc($result))
					{
					    $info["nombre"] = $row['nombre'];
					    $info["id"] = $row['id'];
					    $info["record"] = $row['record'];
					}
                    return $info;
				}
				else
				{
				    return 'NO_EXISTE';
				}
 
 
				break;
 
				case 2:
			    // CASE 2 COMPROBAR RECORDS
				$query = "SELECT nombre, record FROM usuarios ORDER BY record DESC LIMIT 5";
                $result = mysqli_query($connection, $query);
                if($result && mysqli_num_rows($result) > 0)
                    {
 
                        $info = array();
                        while($row = mysqli_fetch_assoc($result))
                    {
                        $info[]=[
                        "nombre" =>$row['nombre'],
                        "record"=> $row['record']
                                ];
                    }
                    return $info;
 
                    }
 
				break;
 
				case 3:
			    // CASE 3 SUBIR RECORDS
 
				$query = "UPDATE usuarios SET record = '$json->record' WHERE id = '$json->id'";
				mysqli_query($connection, $query);
 
					return 'SUBIDO';
 
				break;
 
				case 4:
			    // CASE 4 RECUPERAR PREGUNTAS
				$query = "SELECT 
                preguntas.id AS pregunta_id, 
                preguntas.descripcion AS pregunta_descripcion, 
                respuestas.id AS respuesta_id, 
                respuestas.descripcion AS respuesta_descripcion, 
                respuestas.es_correcta 
                FROM respuestas JOIN preguntas ON preguntas.id = respuestas.pregunta_id";
 
        $result = mysqli_query($connection, $query);
 
        if($result && mysqli_num_rows($result) > 0)
        {
                $preguntas = [];
                while ($row = mysqli_fetch_assoc($result)) {
                    $preguntaId = $row['pregunta_id'];
                    if (!isset($preguntas[$preguntaId])) {
                        $preguntas[$preguntaId] = [
                            'id' => $preguntaId,
                            'descripcion' => $row['pregunta_descripcion']
                        ];
                    }
                    $respuestaId = $row['respuesta_id'];
                    $esCorrecta = $row['es_correcta'];
                    $preguntas[$preguntaId]['respuestas'][] = [
                        'id' => $respuestaId,
                        'descripcion' => $row['respuesta_descripcion'],
                        'es_correcta' => $esCorrecta
                    ];
                    if($esCorrecta==true){
                        $preguntas[$preguntaId]['id_respuesta_correcta']=$respuestaId;
                    }
                }
            
            return ['preguntas' => array_values($preguntas)];
 
        }
        else{
            return "NO_DATOS";
        }break;
 
		}
		return 'NULL';
    }
 
?>