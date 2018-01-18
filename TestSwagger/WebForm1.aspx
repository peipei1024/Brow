<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestSwagger.WebForm1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../Content/template-web.js"></script>
</head>
<body>
    <div id="content"></div>
    <script id="test" type="text/html">
        <h1>{{title}}</h1>
        <ul>
            {{each list as value i}}
                <li onclick="test(this)" value='{{value}}'>狗子{{i + 1}} ：{{value}}</li>
            {{/each}}
        </ul>
    </script>
    <script>
        var data = {
            title: '宝宝喜欢的狗种类',
            list: ['拉布拉多', '萨摩耶', '塞罗纳', '边牧', '京巴', '牛头梗', '松狮']
        };
        var html = template('test', data);
        //document.getElementById('content').innerHTML = html;
    </script>


    <script id="list" type="text/html">
        <ul>
            {{each data as value i}}
                <li onclick="test(this)" value='{{value}}'>{{i + 1}} ：{{value}}</li>
            {{/each}}
        </ul>
        {{if value}} ... {{/if}}
        {{if v1}} ... {{else if v2}} ... {{/if}}
    </script>

    <script>
        var html = template('list', <%=str_m%>);
        document.getElementById('content').innerHTML = html;
    </script>

    <script>
        function test(value) {
            console.log(value.getAttribute('value'))
            alert(value.getAttribute('value'))
        }
    </script>

    
</body>
</html>
