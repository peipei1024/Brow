<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});
Route::get('hello', function () {
    return 'Hello, Welcome to LaravelAcademy.org';
});

Route::get('/user', 'UsersController@index');

Route::redirect('/here', '/there', 301);
//其中 here 表示原路由，there 表示重定向之后的路由，301 是一个 HTTP 状态码，用于标识重定向。

Route::view('/welcome', 'welcome');
Route::view('/view', 'welcome', ['name' => '学院君']);

Route::get('user/{id}', function ($id) {
    return 'User ' . $id;
});

Route::get('posts/{post}/comments/{comment}', function ($postId, $commentId) {
    return $postId . '-' . $commentId;
});

Route::get('user/{name?}', function ($name = null) {
    return $name;
});

Route::get('user/{name?}', function ($name = 'John') {
    return $name;
});


Route::get('user/{name}', function ($name) {
    // name 必须是字母且不能为空
})->where('name', '[A-Za-z]+');

Route::get('user/{id}', function ($id) {
    // id 必须是数字
})->where('id', '[0-9]+');

Route::get('user/{id}/{name}', function ($id, $name) {
    // 同时指定 id 和 name 的数据格式
})->where(['id' => '[0-9]+', 'name' => '[a-z]+']);


Route::get('user/{id}', 'UserController@show');

Route::get('blade', function () {
    return view('child');
});