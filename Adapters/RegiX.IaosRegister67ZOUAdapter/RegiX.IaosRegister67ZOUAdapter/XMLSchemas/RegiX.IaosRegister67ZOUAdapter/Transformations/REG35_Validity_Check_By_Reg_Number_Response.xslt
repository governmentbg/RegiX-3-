<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/IAOS/REG35Reg/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/IAOS/REG35Reg/ValidityCheckByRegNumberResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
							<xsl:text>Справка за валидност по номер на документ в Регистър на разрешенията по чл. 67 ЗУО, в т.ч. на тези от тях с прекратено действие</xsl:text>
						</span>
					</h2>
					<table style="width:50%; " align="center" border="0">
						<tbody>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Тип на регистрацията</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG35_Validity_Check_By_Reg_Number_Response">
									<xsl:for-each select="n1:Authorization">
										<td>
											<xsl:for-each select="n1:AuthType">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Наименование на организацията</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG35_Validity_Check_By_Reg_Number_Response">
									<xsl:for-each select="n1:Authorization">
										<td>
											<xsl:for-each select="n1:CompanyName">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Дата на издаване</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG35_Validity_Check_By_Reg_Number_Response">
									<xsl:for-each select="n1:Authorization">
										<td>
											<xsl:for-each select="n1:DateIssued">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>ЕИК</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG35_Validity_Check_By_Reg_Number_Response">
									<xsl:for-each select="n1:Authorization">
										<td>
											<xsl:for-each select="n1:EIK">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
							<tr>
								<th align="left">
									<span>
										<xsl:text>Статус</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:REG35_Validity_Check_By_Reg_Number_Response">
									<xsl:for-each select="n1:Authorization">
										<td>
											<xsl:for-each select="n1:State">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</xsl:for-each>
								</xsl:for-each>
							</tr>
						</tbody>
					</table>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>