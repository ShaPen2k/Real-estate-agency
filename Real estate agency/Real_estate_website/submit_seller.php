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

    // Получение данных из формы
    $name = $_POST['name'] ?? '';
    $surname = $_POST['surname'] ?? '';
    $phone = $_POST['phone'] ?? '';
    $email = $_POST['email'] ?? '';
    $image = 'user.png';

    // Вставка данных в базу
    $stmt = $conn->prepare("INSERT INTO owners (owner_firstname, owner_lastname, owner_phone, owner_email, image) VALUES (:name, :surname, :phone, :email, :image)");
    $stmt->bindParam(':name', $name);
    $stmt->bindParam(':surname', $surname);
    $stmt->bindParam(':phone', $phone);
    $stmt->bindParam(':email', $email);
    $stmt->bindParam(':image', $image);
    $stmt->execute();

    echo json_encode(['message' => 'Заявка успешно отправлена']);
} catch (PDOException $e) {
    http_response_code(500);
    echo json_encode(['message' => 'Ошибка: ' . $e->getMessage()]);
}

$conn = null;
?>