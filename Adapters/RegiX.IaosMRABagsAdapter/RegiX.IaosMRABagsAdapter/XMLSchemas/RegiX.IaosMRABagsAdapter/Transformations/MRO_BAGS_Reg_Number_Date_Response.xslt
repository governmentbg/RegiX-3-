<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/IAOS/MROBags/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/IAOS/MROBags/RegNumberDateResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h2 align="center">
						<span>
							<xsl:text>Отговор на справка по регистрационен номер в Регистъра на лицата, които пускат на пазара полимерни торбички:</xsl:text>
						</span>
						<br/>
					</h2>
					<br/>
					<table align="center" border="1">
						<thead>
							<tr>
								<th>
									<span>
										<xsl:text>Регистрационен номер</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>Наименование на организацията</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>Начална дата на валидност</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>Крайна дата на валидност</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>Статус</xsl:text>
									</span>
								</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="n1:MRO_BAGS_Reg_Number_Date_Response">
								<xsl:for-each select="n1:Authorization">
									<tr>
										<td>
											<xsl:for-each select="n1:AuthNum">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="n1:CompanyName">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="n1:DateFrom">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="n1:DateTo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="n1:State">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
								</xsl:for-each>
							</xsl:for-each>
						</tbody>
					</table>
					<br/>
					<span>
						<xsl:text>&#160;</xsl:text>
					</span>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
