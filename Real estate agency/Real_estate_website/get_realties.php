<?php
header('Content-Type: application/json');

// Подключение к базе данных
$host = "localhost";
$port = "5432";
$dbname = "Real_Estate_Agency2";
$user = "postgres";
$password = "postgres";

try {
    $dsn = "pgsql:host=$host;port=$port;dbname=$dbname";
    $conn = new PDO($dsn, $user, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // Запрос данных из таблицы realty с соединением realty_type
    $stmt = $conn->query("
        SELECT r.realty_id, r.realty_address, r.realty_price, r.image, r.realty_rooms, t.realty_type_text AS realty_type_name
        FROM realty r
        JOIN realty_type t ON r.realty_type_id = t.realty_type_id
        WHERE r.realty_type_id = 1
        ORDER BY r.realty_id ASC;
    ");
    $apartments = $stmt->fetchAll(PDO::FETCH_ASSOC);

    echo json_encode($apartments);
} catch (PDOException $e) {
    http_response_code(500);
    echo json_encode(['error' => 'Ошибка подключения к базе данных: ' . $e->getMessage()]);
}

$conn = null;
?>