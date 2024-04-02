To startup this project please run the following docker command to start a MSSQL instance container. the username should be 'sa' and the password should be 'reallyStrongPwd123'

docker run --hostname=9a1989a63f34 --user=mssql --mac-address=02:42:ac:11:00:02 --env=PAL_ENABLE_PAGE_ALIGNED_PE_FILE_CREATION=1 --env=LD_LIBRARY_PATH=/opt/mssql/lib --env=MSSQL_SA_PASSWORD=reallyStrongPwd123 --env=ACCEPT_EULA=1 --env=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin --env=MSSQL_RPC_PORT=135 --env=CONFIG_EDGE_BUILD=1 --env=PAL_BOOT_WITH_MINIMAL_CONFIG=1 --volume=/var/opt/mssql-extensibility --volume=/var/opt/mssql-extensibility/data --volume=/var/opt/mssql-extensibility/log --cap-add=SYS_PTRACE -p 1433:1433 --restart=no --label='com.azure.dev.image.build.sourceversion=27968dae20b550ae4cfbd3692ee5bee8d0872ad2' --label='com.azure.dev.image.system.teamfoundationcollectionuri=https://dev.azure.com/tigerdid/' --label='com.microsoft.product=Microsoft SQL Server' --label='com.microsoft.version=15.0.2000.1574' --label='org.opencontainers.image.ref.name=ubuntu' --label='org.opencontainers.image.version=18.04' --label='vendor=Microsoft' --runtime=runc -d mcr.microsoft.com/mssql/server:2022-latest