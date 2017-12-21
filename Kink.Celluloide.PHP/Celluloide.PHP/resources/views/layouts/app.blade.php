<html>
    <head>
        <title>Celluloide-@yield('title')</title>
    </head>
    <body>
        @section('sidebar')
            侧边栏
        @show

        <div class="container">
            @yield('content')
        </div>
    </body>
</html>