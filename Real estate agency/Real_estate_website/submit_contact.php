<?php
header('Content-Type: application/json');

// Подключение к PostgreSQL
$host = "localhost";
$port = "5432";
$dbname = "Real_Estate_Agency2";
$user = "postgres";
$password = "postgres"; // Замените на ваш реальный пароль

try {
    $dsn = "pgsql:host=$host;port=$port;dbname=$dbname";
    $conn = new PDO($dsn, $user, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // Проверка входных данных
    $name = $_POST['name'] ?? '';
    $surname = $_POST['surname'] ?? '';
    $phone = $_POST['phone'] ?? '';
    $email = $_POST['email'] ?? '';
    $realtyId = isset($_POST['realty_id']) && !empty($_POST['realty_id']) ? (int)$_POST['realty_id'] : null;
    $image = 'user.png';

    if (empty($name) || empty($surname) || empty($phone)) {
        throw new Exception("Все обязательные поля (имя, фамилия, телефон) должны быть заполнены.");
    }

    $conn->beginTransaction();

    // Получаем новый client_id
    $stmt = $conn->query("SELECT COALESCE(MAX(client_id), 0) + 1 FROM clients");
    $newClientId = $stmt->fetchColumn();

    // Вставляем клиента с новым client_id
    $stmt = $conn->prepare("INSERT INTO clients (client_id, client_firstname, client_lastname, client_phone, client_email, image)
                            VALUES (:client_id, :name, :surname, :phone, :email, :image)");
    $stmt->bindParam(':client_id', $newClientId, PDO::PARAM_INT);
    $stmt->bindParam(':name', $name);
    $stmt->bindParam(':surname', $surname);
    $stmt->bindParam(':phone', $phone);
    $stmt->bindParam(':email', $email);
    $stmt->bindParam(':image', $image);
    $stmt->execute();

    // Если указан realty_id, проверяем и вставляем запрос клиента
    if ($realtyId) {
        $stmt = $conn->prepare("SELECT 1 FROM realty WHERE realty_id = :realty_id");
        $stmt->bindParam(':realty_id', $realtyId, PDO::PARAM_INT);
        $stmt->execute();

        if ($stmt->rowCount() === 0) {
            throw new Exception("Указанный realty_id не существует.");
        }

        // Получаем новый client_request_id
        $stmt = $conn->query("SELECT COALESCE(MAX(client_request_id), 0) + 1 FROM client_requests");
        $newRequestId = $stmt->fetchColumn();

        // Вставляем запрос клиента
        $stmt = $conn->prepare("INSERT INTO client_requests (client_request_id, client_id, realty_id)
                                VALUES (:request_id, :client_id, :realty_id)");
        $stmt->bindParam(':request_id', $newRequestId, PDO::PARAM_INT);
        $stmt->bindParam(':client_id', $newClientId, PDO::PARAM_INT);
        $stmt->bindParam(':realty_id', $realtyId, PDO::PARAM_INT);
        $stmt->execute();
    }

    $conn->commit();

    echo json_encode(['message' => 'Заявка успешно отправлена']);
} catch (Exception $e) {
    if ($conn && $conn->inTransaction()) {
        $conn->rollBack();
    }
    http_response_code(500);
    echo json_encode(['message' => 'Ошибка: ' . $e->getMessage()]);
} finally {
    $conn = null;
}
?>