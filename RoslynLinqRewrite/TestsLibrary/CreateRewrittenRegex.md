
# Create method calls
Find regex: \[NoRewrite\]\n.*?(\w+)(\(.*)((\n.*?)*)//EndMethod\n
Replace with: TestsExtensions.TestEquals(nameof($1), $1, $1Rewritten);

# Created rewritten methods
Find regex: \[NoRewrite\]\n(.*\w+)(\(.*)((\n.*?)*)//EndMethod
Replace with: [NoRewrite]\n$1$2$3//EndMethod\n\n$1Rewritten$2$3//EndMethod\n