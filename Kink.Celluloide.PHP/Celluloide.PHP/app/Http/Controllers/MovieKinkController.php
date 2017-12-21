<?php
/**
 * Created by PhpStorm.
 * User: pei
 * Date: 2017/12/21
 * Time: 10:57
 */
namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class MovieKinkController extends Controller
{
    /**
     * 为指定用户显示详情
     *
     * @param int $id
     * @return Response
     * @author LaravelAcademy.org
     */
    public function show($id)
    {
        return view('user.profile', ['user' => User::findOrFail($id)]);
//        return view('welcome', ['name' => '学院君']);
//        return view('user.welcome', ['name' => '445']);
    }


    public function showMovie($page){
    }
}