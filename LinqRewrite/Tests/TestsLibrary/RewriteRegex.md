\[NoRewrite\](\n.*?)(\w*)\(\)((\n.*?)*?)\/\/EndMethod

TestsExtensions.TestEquals(nameof($2), $2, $2Rewritten);
[NoRewrite]$1$2()$3 //EndMethod\n$1$2Rewritten()$3 //EndMethod\n\n
