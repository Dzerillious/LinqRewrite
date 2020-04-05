
# Created rewritten methods
Find regex: \[NoRewrite, Benchmark\]\n(.*\w+)(\(.*)((\n.*?)*)//EndMethod
Replace with: [NoRewrite, Benchmark]\n$1$2$3//EndMethod\n\n\t\t[Benchmark]\n$1Rewritten$2$3//EndMethod\n